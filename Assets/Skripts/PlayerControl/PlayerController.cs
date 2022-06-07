using UnityEngine;
using UnityEngine.InputSystem;
using SOD.Movement;
using SOD.Animations;
using SOD.Fight;
using SOD.Enums;

namespace SOD.Control
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerInput))]

    public class PlayerController : MonoBehaviour
    {
        private Vector2 _inputValue;
        private PlayerMovement _movement;
        private AnimationControl _animationControl;
        private PlayerFight _playerFight;
        private StaminaControl _staminaControl;

        private bool _isCanMove = true;

        public bool IsCanMove 
        { set 
            {
                _isCanMove = value;
                _movement.IsCanMove = value;

                if (value)
                {
                    Move(_inputValue);
                }
                else
                {
                    Move(Vector3.zero);
                }
            }
        }

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _animationControl = GetComponent<AnimationControl>();
            _playerFight = GetComponent<PlayerFight>();
            _staminaControl = GetComponent<StaminaControl>();
  
        }

        private void OnMove(InputValue value)
        {
            _inputValue = value.Get<Vector2>();

            if (!_isCanMove) return;
            Move(_inputValue);
        }

        private void OnDash(InputValue value)
        {
            if (!_staminaControl.Dash()) return;
            _movement.Dash();
        }

        private void OnAttack(InputValue value)
        {
             WeaponType weaponType = _playerFight.GetAttackType();
            if (!_staminaControl.Attack(weaponType)) return;

            _animationControl.Attack(weaponType);
        }

        private void Move(Vector2 inputValue)
        {
            _movement.MoveInput = inputValue;
            _animationControl.UpdateMoveInput(inputValue);
        }
    }
}