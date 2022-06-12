using UnityEngine;
using SOD.EnemyAnimations;
using UnityEngine.AI;

namespace SOD.EnemyPatrolling
{
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _waitingTimeAtPoint;

        private NavMeshAgent _meshAgent;
        private EnemyAnimationControl _animationControl;

        private int _currentPointIndex = 0;
        private float _currentWaitingTimeAtPoint;
        private Vector3 _enemyStartPosition;

        private void Awake()
        {
            _meshAgent = GetComponent<NavMeshAgent>();
            _animationControl = GetComponent<EnemyAnimationControl>();
        }

        private void Start()
        {
            _enemyStartPosition = transform.position;
        }

        public void Patrool()
        {
            Vector3 moveTarget = _enemyStartPosition;

            bool atWaypoint = AtWaypoint();

            if (_patrolPath != null)
            {
                if (atWaypoint && _currentWaitingTimeAtPoint >= _waitingTimeAtPoint)
                {
                    _currentWaitingTimeAtPoint = 0;
                    _currentPointIndex = _patrolPath.GetNextIndex(_currentPointIndex);
                }

                moveTarget = _patrolPath.GetWaypoint(_currentPointIndex);
            }
            _meshAgent.SetDestination(moveTarget);
        }

        private bool AtWaypoint()
        {
            float distance = Vector3.Distance(transform.position, _meshAgent.destination);

            if (distance < 0.1f)
            {
                _animationControl.SetDirection(0f,0f);
                _currentWaitingTimeAtPoint += Time.fixedDeltaTime;
                return true;
            }
            else
            {
                _animationControl.SetDirection(0f, 1f);
                return false;
            }
        }
    }
}