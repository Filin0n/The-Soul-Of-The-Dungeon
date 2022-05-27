using UnityEngine;
using SOD.Enums;


namespace SOD.Fight
{
    public class PlayerFight : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        public void SetIsCanHurt(bool canHurt)
        {
            _weapon.SetCanHurt(canHurt);
        }

        public AttackType GetAttackType()
        {
            return _weapon.WeaponAttackType;
        }
    }
}