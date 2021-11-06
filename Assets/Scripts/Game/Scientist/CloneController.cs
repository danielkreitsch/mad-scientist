using System.Linq;
using Development.Debugging;
using Game.Player;
using GameJam;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Character
{
    public class CloneController : MonoBehaviour
    {
        [Inject]
        private DebugScreen debugScreen;

        [Inject]
        private GameController gameController;

        [Inject]
        private PlayerController playerController;

        private Scientist scientist;
        private NavMeshAgent navMeshAgent;

        private float decisionTimer = 0;

        public CloneState State { get; set; }

        private void Awake()
        {
            this.scientist = this.GetComponent<Scientist>();
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();

            this.State = CloneState.Idle;
        }

        private void OnDisable()
        {
            this.navMeshAgent.isStopped = true;
        }

        private void Update()
        {
            this.decisionTimer += Time.deltaTime;
            if (this.decisionTimer > 1)
            {
                this.decisionTimer = 0;
                
                var myAttackers = this.gameController.GetAttackersOfScientist(this.scientist);
                if (myAttackers.Count > 0)
                {
                    this.State = CloneState.ProtectMyself;
                    this.scientist.AttackTarget = myAttackers[0];
                }
                else
                {
                    var closestAttackedScientist = this.gameController.Scientists
                        .FindAll(s => this.scientist != s && this.gameController.GetAttackersOfScientist(s).Count > 0)
                        .OrderBy(s => Vector3.Distance(this.transform.position, s.transform.position))
                        .FirstOrDefault();

                    if (closestAttackedScientist != null)
                    {
                        this.State = CloneState.ProtectOtherScientist;
                        this.scientist.ProtectTarget = closestAttackedScientist;
                    }
                    else
                    {
                        this.State = CloneState.Idle;
                    }
                }
            }

            if (this.State == CloneState.Idle)
            {
            }
            else if (this.State == CloneState.ProtectMyself)
            {
                if (this.scientist.AttackTarget != null && this.scientist.AttackTarget.IsAlive)
                {
                    this.navMeshAgent.stoppingDistance = 8;
                    this.navMeshAgent.SetDestination(this.scientist.AttackTarget.transform.position);
                    
                    this.scientist.ShootAt(this.scientist.AttackTarget.transform.position);
                }
            }
            else if (this.State == CloneState.ProtectOtherScientist)
            {
                var distanceToProtectTarget = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                    new Vector2(this.scientist.ProtectTarget.transform.position.x, this.scientist.ProtectTarget.transform.position.z));

                if (distanceToProtectTarget < 9)
                {
                    var protectTargetAttackers = this.gameController.GetAttackersOfScientist(this.scientist.ProtectTarget);
                    if (protectTargetAttackers.Count > 0)
                    {
                        this.scientist.AttackTarget = protectTargetAttackers[0];
                    }
                    else
                    {
                        this.State = CloneState.Idle;
                    }
                }

                if (distanceToProtectTarget > 6)
                {
                    this.navMeshAgent.stoppingDistance = 4;
                    this.navMeshAgent.SetDestination(this.scientist.ProtectTarget.transform.position);
                }
                else
                {
                    this.navMeshAgent.stoppingDistance = 8;
                    this.navMeshAgent.SetDestination(this.scientist.AttackTarget.transform.position);
                }

                if (this.scientist.AttackTarget != null && this.scientist.AttackTarget.IsAlive)
                {
                    this.scientist.ShootAt(this.scientist.AttackTarget.transform.position);
                }
            }

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

        private float GetOptimalDistance()
        {
            int nearScientists = this.gameController.Scientists.Count(s => Vector3.Distance(this.transform.position, s.transform.position) < 3);
            if (nearScientists < 5)
            {
                return 1;
            }
            else if (nearScientists < 10)
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