using UnityEngine;
using SOD.Item;


namespace SOD.Fight
{
    public class PlayerFight : MonoBehaviour
    {
        private AttackType _weaponType = AttackType.TwoHandSword;

        public AttackType Attack()
        {
            return _weaponType;
        }
    }
}