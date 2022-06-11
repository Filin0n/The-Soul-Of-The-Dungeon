using UnityEngine;
using UnityEngine.AI;

namespace SOD.EnemyMovement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveToTarget : MonoBehaviour
    {
        private NavMeshAgent _meshAgent;

        private void Awake()
        {
            _meshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 target)
        {
            _meshAgent.SetDestination(target);
        }
    }
}