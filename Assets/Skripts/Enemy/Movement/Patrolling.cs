using UnityEngine;

namespace SOD.EnemyMovement
{
    [RequireComponent(typeof(MoveToTarget))]
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _waitingTimeAtPoint;

        private MoveToTarget _moveToTarget;
        
        private int _currentPointIndex = 0;
        private float _currentWaitingTimeAtPoint;
        private Vector3 _enemyStartPosition;

        private void Awake()
        {
            _moveToTarget = GetComponent<MoveToTarget>();
        }

        private void Start()
        {
            _enemyStartPosition = transform.position;
        }

        private void FixedUpdate()
        {
            Patrool();
        }

        private void Patrool()
        {
            Vector3 moveTarget = _enemyStartPosition;

            if (_patrolPath != null)
            {
                if (AtWaypoint() && _currentWaitingTimeAtPoint >= _waitingTimeAtPoint)
                {
                    _currentWaitingTimeAtPoint = 0;
                    _currentPointIndex = _patrolPath.GetNextIndex(_currentPointIndex);
                }

                moveTarget = _patrolPath.GetWaypoint(_currentPointIndex);
            }

            _moveToTarget.MoveTo(moveTarget);
        }

        private bool AtWaypoint()
        {
            float distance = Vector3.Distance(transform.position, _patrolPath.GetWaypoint(_currentPointIndex));

            if (distance < 1f)
            {
                // ¬ключить idle анимацию

                _currentWaitingTimeAtPoint += Time.fixedDeltaTime;
                return true;
            }
            else
            {
                // ¬ключить анимацию ходьбы

                return false;
            }
        }
    }
}