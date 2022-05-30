using UnityEngine;
using SOD.Enums;

namespace SOD.Fight
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _weaponID;
        [SerializeField] private AttackType _attackType;
        [SerializeField] private int _damage;

        [SerializeField] private bool _isCanHurt;

        public int WeaponID => _weaponID;

        private void OnEnable()
        {
            _isCanHurt = false;
        }

        public AttackType WeaponAttackType => _attackType;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isCanHurt) return;

            if(other.TryGetComponent(out EnemyHP hp))
            {
                Debug.Log("Hit");
                hp.TakeDamage(_damage);
            }
        }

        public void SetCanHurt(bool canHurt)
        {
            _isCanHurt = canHurt;
        }
    }
}
