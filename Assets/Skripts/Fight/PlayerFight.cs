using System.Collections.Generic;
using UnityEngine;
using SOD.Enums;

namespace SOD.Fight
{
    public class PlayerFight : MonoBehaviour
    {
        [Header("Right hand")]
        [SerializeField] private List<Weapon> _weapns;

        private Weapon _currentWeapon;

        private void Start()
        {
            ChaingeWeapon(0);
        }

        public void SetIsCanHurt(bool canHurt)
        {
            _currentWeapon.SetCanHurt(canHurt);
        }

        public AttackType GetAttackType()
        {
            return _currentWeapon?.WeaponAttackType ?? AttackType.Empty;
        }

        public void ChaingeWeapon(int weaponID)
        {
            _currentWeapon?.gameObject.SetActive(false);

            foreach (Weapon weapon in _weapns)
            {
                if (weapon.WeaponID == weaponID)
                {
                    _currentWeapon = _weapns[weaponID];
                }
            }

            _currentWeapon?.gameObject.SetActive(true);
        }
    }
}