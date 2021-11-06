using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Development.Debugging;
using Game.Character;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Zenject;

namespace GameJam
{
    public class ZombieController : MonoBehaviour
    {
        [Inject]
        private DebugScreen debugScreen;

        [Inject]
        private GameController gameController;

        private Zombie zombie;
        private NavMeshAgent navMeshAgent;

        private float idleTimer = 0;

        public EnemyState State { get; set; }

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
            if (this.State == EnemyState.Idle)
            {
                this.idleTimer += Time.deltaTime;
                if (this.idleTimer >= 1)
                {
                    this.idleTimer = 0;
                    
                    if (this.gameController.Scientists.Count > 0)
                    {
                        var target = this.gameController.Scientists.OrderBy(scientist => Vector3.Distance(this.transform.position, scientist.transform.position)).First();
                        this.zombie.Target = target;
                        this.State = EnemyState.WalkToScientist;
                    }
                }
            }
            else if (this.State == EnemyState.WalkToScientist)
            {
                this.navMeshAgent.stoppingDistance = 1.1f;

                var distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                    new Vector2(this.zombie.Target.transform.position.x, this.zombie.Target.transform.position.z));

                if (distance < 1.1f)
                {
                    this.navMeshAgent.isStopped = true;
                    this.State = EnemyState.Attack;
                }
                else
                {
                    this.navMeshAgent.isStopped = false;
                    this.navMeshAgent.SetDestination(this.zombie.Target.transform.position);
                }
            }
            else if (this.State == EnemyState.Attack)
            {
                this.State = EnemyState.Idle;
            }
            
            this.debugScreen.Set("Zombie", "State", this.State.ToString());

            /*int nearZombies = this.gameController.Zombies.Count(zombie => Vector3.Distance(this.transform.position, zombie.transform.position) < 3);
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
            }*/
        }
    }
}