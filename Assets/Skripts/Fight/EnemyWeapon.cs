using UnityEngine;

namespace SOD.Fight
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHP hP))
            {
                hP.TakeDamage(_damage);
            }
        }
    }
}
