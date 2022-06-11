using UnityEngine;
using SOD.EnemyMovement;
using SOD.EnemyFight;
using SOD.CycleOfDeath;

namespace SOD.EnemyControll
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _agroRadius = 3f;

        private EnemyAttack _enemyAttack;
        private Patrolling _patrolling;
        private Transform _player;

        private void Awake()
        {
            _enemyAttack = GetComponent<EnemyAttack>();
            _patrolling = GetComponent<Patrolling>();
            _player = CycleOfDeathManager.Player.transform;
        }

        private void FixedUpdate()
        {
            if (PlayerInAgroradius())
            {
                _patrolling.enabled = false;
                _enemyAttack.enabled = true;
            }
            else
            {
                _patrolling.enabled = true;
                _enemyAttack.enabled = false;
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position,_agroRadius);
        }
    }
}