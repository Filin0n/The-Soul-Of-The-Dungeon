using UnityEngine;

namespace SOD.EnemyFight
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private bool _isCanHurt = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHP hP))
            {
                if (!_isCanHurt) return;

                hP.TakeDamage(_damage);
            }
        }

        public void SetCanHurt(bool canHurt)
        {
            _isCanHurt = canHurt;
        }
    }
}
