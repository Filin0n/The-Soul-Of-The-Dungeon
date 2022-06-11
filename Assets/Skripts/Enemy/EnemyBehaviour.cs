using UnityEngine;

namespace SOD.EnemyBehaviour
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float _agroRadius = 3f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position,_agroRadius);
        }
    }
}