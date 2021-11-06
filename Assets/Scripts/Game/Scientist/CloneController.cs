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
            if (this.State == CloneState.Idle)
            {
                var target = this.gameController.Scientists
                    .FindAll(scientist => this.scientist != scientist && this.gameController.GetAttackersOfScientist(scientist).Count > 0)
                    .OrderBy(scientist => Vector3.Distance(this.transform.position, scientist.transform.position))
                    .FirstOrDefault();

                if (target == null)
                {
                    target = this.playerController.GetComponent<Scientist>();
                }
                
                if (target != null)
                {
                    this.scientist.ProtectTarget = target;
                    this.State = CloneState.ProtectOtherScientist;
                }
            }
            else if (this.State == CloneState.ProtectOtherScientist)
            {
                var myAttackers = this.gameController.GetAttackersOfScientist(this.scientist);
                if (myAttackers.Count > 0)
                {
                    this.scientist.AttackTarget = myAttackers[0];
                }
                else
                {
                    var distance = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z),
                        new Vector2(this.scientist.ProtectTarget.transform.position.x, this.scientist.ProtectTarget.transform.position.z));

                    if (distance < 9)
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

                    if (distance > 10)
                    {
                        this.navMeshAgent.stoppingDistance = 4;
                        this.navMeshAgent.SetDestination(this.scientist.ProtectTarget.transform.position);
                    }
                }

                if (this.scientist.AttackTarget != null && this.scientist.AttackTarget.IsAlive)
                {
                    this.scientist.ShootAt(this.scientist.AttackTarget.transform.position);
                }
            }

            else if (this.State == CloneState.ShootEnemy)
            {
                if (this.scientist.AttackTarget != null && this.scientist.AttackTarget.IsAlive)
                {
                    this.scientist.ShootAt(this.scientist.AttackTarget.transform.position);
                }
            }

            int nearScientists = this.gameController.Scientists.Count(scientist => Vector3.Distance(this.transform.position, scientist.transform.position) < 3);
            if (nearScientists < 5)
            {
                this.navMeshAgent.radius = Mathf.Min(this.navMeshAgent.radius + 0.1f * Time.deltaTime, 1);
            }
            else if (nearScientists < 10)
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
    }
}