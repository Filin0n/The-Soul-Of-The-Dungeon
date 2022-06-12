using UnityEngine;
using UnityEngine.AI;
using SOD.CycleOfDeath;
using SOD.EnemyAnimations;

namespace SOD.EnemyFight
{
    public class EnemyFightBehaviour : MonoBehaviour
    {
        [SerializeField] private float _minDistToPayer = 1.5f;

        private Transform _player;
        private NavMeshAgent _meshAgent;
        private EnemyAnimationControl _enemyAnimation;

        private void Awake()
        {
            _player = CycleOfDeathManager.Player.transform;
            _meshAgent = GetComponent<NavMeshAgent>();
            _enemyAnimation = GetComponent<EnemyAnimationControl>();
        }

        public void FightBehaviour()
        {
            float distToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distToPlayer > _minDistToPayer)
            {
                MoveToPlayer();
                _enemyAnimation.ResetTriggers();
            }
            else
            {
                Attack();
            }
        }

        private void MoveToPlayer()
        {
            _meshAgent.SetDestination(_player.position);
            _enemyAnimation.SetDirection(0f,1f);
        }

        private void Attack()
        {
            LookAtPlayer();
            _meshAgent.SetDestination(transform.position);
            _enemyAnimation.SetDirection(0f, 0f);
            _enemyAnimation.Attack();
        }

        private void LookAtPlayer()
        {
            Vector3 lookAt = _player.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
        }
    }
}