using UnityEngine;
using SOD.CycleOfDeath;
using SOD.EnemyMovement;
using SOD.EnemyAnimations;

namespace SOD.EnemyFight
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _minDistToPayer = 1.5f;

        private Transform _player;
        private MoveToTarget _moveTo;
        private EnemyAnimationControl _enemyAnimation;

        private void Awake()
        {
            _player = CycleOfDeathManager.Player.transform;
            _moveTo = GetComponent<MoveToTarget>();
            _enemyAnimation = GetComponent<EnemyAnimationControl>();
        }

        private void FixedUpdate()
        {
            float distToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distToPlayer > _minDistToPayer)
            {
                MoveToPlayer();
            }
            else
            {
                Attack();
            }
        }

        private void MoveToPlayer()
        {
            _moveTo.SetTarget(_player.position);
            _enemyAnimation.SetDirection(0f,1f);
        }

        private void Attack()
        {
            LookAtPlayer();
            _moveTo.SetTarget(transform.position);
            _enemyAnimation.SetDirection(0f, 0f);
        }

        private void LookAtPlayer()
        {
            Vector3 lookAt = _player.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
        }
    }
}