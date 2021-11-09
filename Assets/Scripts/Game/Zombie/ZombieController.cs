using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using Development.Debugging;
using Game.Character;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Utility;
using Zenject;
using Random = UnityEngine.Random;

namespace GameJam
{
    public class ZombieController : MonoBehaviour
    {
        [Inject]
        private DebugScreen debugScreen;

        [Inject]
        private GameController gameController;

        [SerializeField]
        private Transform rotatingTransform;

        [SerializeField]
        private Collider attackCollider;

        [SerializeField]
        private float chaseTimeBeforeSwitching = 10;
        
        [SerializeField]
        private bool distanceOptimizationEnabled;
        
        [SerializeField]
        private float rotationInterpolationTime = 1;

        [SerializeField]
        private AudioClip attackSound;

        private Zombie zombie;
        private NavMeshAgent navMeshAgent;

        private float idleTimer = 0;
        private float decisionTimer = 0;
        private float chaseTime = 0;
        private float attackTimer = 0;

        private Scientist closestScientist;
        
        private Vector3 rotationVelocity;

        public EnemyState State { get; set; }
        
        public Scientist Target
        {
            get => this.zombie.Target;
            set
            {
                this.zombie.Target = value;
                this.chaseTime = 0;
            }
        }

        private void Awake()
        {
            this.zombie = this.GetComponent<Zombie>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();

            this.State = EnemyState.Idle;
        }

        private void OnDisable()
        {
            this.navMeshAgent.isStopped = true;
        }

        private void Update()
        {
            if (this.zombie.Target != null)
            {
                if (!this.zombie.Target.IsAlive)
                {
                    this.zombie.Target = null;
                    this.State = EnemyState.Idle;
                }
            }

            this.decisionTimer += Time.deltaTime;
            if (this.decisionTimer > 1)
            {
                this.decisionTimer = 0;
                this.closestScientist = this.gameController.Scientists.OrderBy(scientist => Vector3.Distance(this.transform.position, scientist.transform.position)).FirstOrDefault();
            }
            
            if (this.State == EnemyState.Idle)
            {
                this.idleTimer += Time.deltaTime;
                if (this.idleTimer >= 1)
                {
                    this.idleTimer = 0;
                    
                    if (this.gameController.Scientists.Count > 0)
                    {
                        var target = this.closestScientist;
                        if (Random.Range(0, 1000) > 500)
                        {
                            var playerObj = GameObject.FindObjectOfType<PlayerController>();
                            if (playerObj != null)
                            {
                                target = playerObj.GetComponent<Scientist>();
                            }
                        }
                        this.Target = target;
                        this.State = EnemyState.WalkToScientist;
                    }
                }
            }
            else if (this.State == EnemyState.WalkToScientist)
            {
                if (this.zombie.Target == null)
                {
                    this.State = EnemyState.Idle;
                    return;
                }
                
                this.attackTimer += Time.deltaTime;
                
                //this.navMeshAgent.stoppingDistance = 1.1f;

                var distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                    new Vector2(this.Target.transform.position.x, this.zombie.Target.transform.position.z));

                if (distance < 1.5f)
                {
                    this.chaseTime = 0;
                    this.navMeshAgent.isStopped = true;

                    if (this.attackTimer >= 0.1f)
                    {
                        this.State = EnemyState.Attack;
                    }
                }
                else
                {
                    this.navMeshAgent.isStopped = false;
                    this.navMeshAgent.SetDestination(this.zombie.Target.transform.position);

                    this.chaseTime += Time.deltaTime;
                    if (this.chaseTime > this.chaseTimeBeforeSwitching)
                    {
                        this.Target = this.closestScientist;
                    }
                }
            }
            else if (this.State == EnemyState.Attack)
            {
                this.attackTimer = 0;
                this.StartCoroutine(this.Attack_Coroutine());
            }

            if (this.navMeshAgent.velocity.magnitude > 0)
            {
                var lookDirection = this.navMeshAgent.velocity;
                if (this.Target != null && this.navMeshAgent.velocity.magnitude < 0.3f)
                {
                    lookDirection = this.Target.transform.position - this.transform.position;
                }
                this.rotatingTransform.rotation = MathUtilty.SmoothDampQuaternion(this.rotatingTransform.rotation, Quaternion.LookRotation(lookDirection), ref this.rotationVelocity, this.rotationInterpolationTime);
            }

            this.debugScreen.Set("Zombie", "State", this.State.ToString());

            if (this.distanceOptimizationEnabled)
            {
                float optimalDistance = this.GetOptimalDistance();
                if (!Mathf.Approximately(this.navMeshAgent.radius, optimalDistance))
                {
                    if (this.navMeshAgent.radius < optimalDistance)
                    {
                        this.navMeshAgent.radius = Mathf.Min(this.navMeshAgent.radius + 0.1f * Time.deltaTime, optimalDistance);
                    }
                    else if (this.navMeshAgent.radius > optimalDistance)
                    {
                        this.navMeshAgent.radius = Mathf.Max(this.navMeshAgent.radius - 0.1f * Time.deltaTime, optimalDistance);
                    }
                }
            }
        }

        private IEnumerator Attack_Coroutine()
        {
            this.attackCollider.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.1f);
            
            this.attackCollider.gameObject.SetActive(false);
            
            this.State = EnemyState.WalkToScientist;
        }
        
        private float GetOptimalDistance()
        {
            int nearZombies = this.gameController.Zombies.Count(zombie => Vector3.Distance(this.transform.position, zombie.transform.position) < 3);
            if (nearZombies < 5)
            {
                return 1;
            }
            else if (nearZombies < 10)
            {
                return 0.6f;
            }
            else
            {
                return 0.5f;
            }
        }
    }
}