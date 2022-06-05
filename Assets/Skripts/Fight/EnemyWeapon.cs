using UnityEngine;

namespace SOD.Fight
{
    public class EnemyWeapon : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHP hP))
            {
                hP.TakeDamage(10);
            }
        }
    }
}
