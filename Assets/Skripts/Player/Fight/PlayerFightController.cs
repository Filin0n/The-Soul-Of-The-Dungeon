using System.Collections.Generic;
using UnityEngine;
using SOD.Enums;

namespace SOD.PlayerFight
{
    public class PlayerFightController : MonoBehaviour
    {
        [Header("Right hand")]
        [SerializeField] private List<PlayerWeapon> _weapns;

        private PlayerWeapon _currentWeapon;

        private void Start()
        {
            ChaingeWeapon(0);
        }

        public void SetIsCanHurt(bool canHurt)
        {
            _currentWeapon.SetCanHurt(canHurt);
        }

        public WeaponType GetAttackType()
        {
            return _currentWeapon?.WeaponAttackType ?? WeaponType.Empty;
        }

        public void ChaingeWeapon(int weaponID)
        {
            _currentWeapon?.gameObject.SetActive(false);

            foreach (PlayerWeapon weapon in _weapns)
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