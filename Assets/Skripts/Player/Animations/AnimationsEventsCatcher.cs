using UnityEngine;
using SOD.PlayerFight;
using SOD.Control;

namespace SOD.Animations
{
    public class AnimationsEventsCatcher : MonoBehaviour
    {
        [SerializeField] private PlayerFight.PlayerFightController _playerFight;
        [SerializeField] private PlayerController _playerController;

        public void CanAttack()
        {
            _playerFight?.SetIsCanHurt(true);
        }

        public void CantAttack()
        {
            _playerFight?.SetIsCanHurt(false);
        }

        public void CanMove()
        {
            if (_playerController == null) return;

            //Debug.Log("Can move event");

            _playerController.IsCanMove = true;
        }

        public void CantMove()
        {
            if (_playerController == null) return;

            //Debug.Log("Can't move event");

            _playerController.IsCanMove = false;
        }
    }
}