using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using Development.Debugging;
using Game.Character;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
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

        [Inject]
        private PlayerController playerController;

        [SerializeField]
        private Collider attackCollider;

        [SerializeField]
        private float chaseTimeBeforeSwitching = 10;

        private Zombie zombie;
        private NavMeshAgent navMeshAgent;

        private float idleTimer = 0;
        private float decisionTimer = 0;
        private float chaseTime = 0;
        private float attackTimer = 0;

        private Scientist closestScientist;

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
                        var target = this.playerController.GetComponent<Scientist>();
                        if (Random.Range(0, 1000) < 500)
                        {
                            target = this.gameController.Scientists.OrderBy(scientist => Vector3.Distance(this.transform.position, scientist.transform.position)).First();
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
                
                this.navMeshAgent.stoppingDistance = 1.1f;

                var distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                    new Vector2(this.Target.transform.position.x, this.zombie.Target.transform.position.z));

                if (distance < 1.1f)
                {
                    this.chaseTime = 0;
                    this.navMeshAgent.isStopped = true;

                    if (this.attackTimer < 2)
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
            
            this.debugScreen.Set("Zombie", "State", this.State.ToString());

            int nearZombies = this.gameController.Zombies.Count(zombie => Vector3.Distance(this.transform.position, zombie.transform.position) < 3);
            if (nearZombies < 5)
            {
                this.navMeshAgent.radius = Mathf.Min(this.navMeshAgent.radius + 0.1f * Time.deltaTime, 1);
            }
            else if (nearZombies < 10)
            {
                if (this.navMeshAgent.radius < 0.6f)
                {
                    this.navMeshAgent.radius = Mathf.Min(this.navMeshAgent.radius + 0.1f * Time.deltaTime, 0.6f);
                }
                else if (this.navMeshAgent.radius > 0.6f)
                {
                    this.navMeshAgent.radius = Mathf.Max(this.navMeshAgent.radius - 0.1f * Time.deltaTime, 0.6f);
                }
            }
            else
            {
                if (this.navMeshAgent.radius < 0.5f)
                {
                    this.navMeshAgent.radius = Mathf.Min(this.navMeshAgent.radius + 0.1f * Time.deltaTime, 0.5f);
                }
                else if (this.navMeshAgent.radius > 0.5f)
                {
                    this.navMeshAgent.radius = Mathf.Max(this.navMeshAgent.radius - 0.1f * Time.deltaTime, 0.5f);
                }
            }
        }

        private IEnumerator Attack_Coroutine()
        {
            this.attackCollider.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            
            this.attackCollider.gameObject.SetActive(false);
            
            this.State = EnemyState.WalkToScientist;
        }
    }
}