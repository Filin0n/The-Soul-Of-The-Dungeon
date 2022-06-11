using UnityEngine;
using SOD.EnemyAnimations;

namespace SOD.EnemyMovement
{
    [RequireComponent(typeof(MoveToTarget))]
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _waitingTimeAtPoint;
        
        private MoveToTarget _moveToTarget;
        private EnemyAnimationControl _animationControl;

        private int _currentPointIndex = 0;
        private float _currentWaitingTimeAtPoint;
        private Vector3 _enemyStartPosition;

        private void Awake()
        {
            _moveToTarget = GetComponent<MoveToTarget>();
            _animationControl = GetComponent<EnemyAnimationControl>();
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

            _moveToTarget.SetTarget(moveTarget);
        }

        private bool AtWaypoint()
        {
            float distance = Vector3.Distance(transform.position, _moveToTarget.GetDistination());

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