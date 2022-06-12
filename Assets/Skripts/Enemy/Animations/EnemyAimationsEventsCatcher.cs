using UnityEngine;
using SOD.EnemyControll;

namespace SOD.EnemyAnimations
{
    public class EnemyAimationsEventsCatcher : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyController;

        public void CanAttack()
        {
            _enemyController.EnemyWeapon.SetCanHurt(true);
        }

        public void CantAttack()
        {
            _enemyController.EnemyWeapon.SetCanHurt(false);
        }

        public void CanMove()
        {
            _enemyController.IsCanMove = true;
        }

        public void CantMove()
        {
            _enemyController.IsCanMove = false;
        }
    }
}
