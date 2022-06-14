using UnityEngine;
using UnityEngine.AI;
using SOD.EnemyPatrolling;
using SOD.EnemyFight;
using SOD.CycleOfDeath;
using SOD.EnemyAnimations;

namespace SOD.EnemyControll
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _agroRadius = 3f;
        [SerializeField] private EnemyWeapon _enemyWeapon;

        private EnemyFightBehaviour _fightBehaviour;
        private Patrolling _patrolling;
        private NavMeshAgent _meshAgent;
        private EnemyAnimationControl _enemyAnimation;
        private Transform _player;

        private bool _isCanMove = true;

        public EnemyWeapon EnemyWeapon => _enemyWeapon;
        public bool IsCanMove
        {
            get
            {
                return _isCanMove;
            }
            set
            {
                _isCanMove = value;
            }
        }

        private void Awake()
        {
            _fightBehaviour = GetComponent<EnemyFightBehaviour>();
            _patrolling = GetComponent<Patrolling>();
            _meshAgent = GetComponent<NavMeshAgent>();
            _enemyAnimation = GetComponent<EnemyAnimationControl>();
            _player = CycleOfDeathManager.Player.transform;
        }

        private void FixedUpdate()
        {
            if (!_isCanMove)
            {
                _meshAgent.SetDestination(transform.position);
                _enemyAnimation.SetDirection(0f,0f);
                return;
            }

            if (PlayerInAgroradius())
            {
                _fightBehaviour.FightBehaviour();
            }
            else
            {
                _patrolling.Patrool();
            }
        }

        private bool PlayerInAgroradius()
        {
            float distToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distToPlayer < _agroRadius) 
            {
                return true;
            }
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _agroRadius);
        }
    }
}