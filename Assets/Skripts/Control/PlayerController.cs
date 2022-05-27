using UnityEngine;
using UnityEngine.InputSystem;
using SOD.Movement;
using SOD.Animations;
using SOD.Fight;
using SOD.Item;

namespace SOD.Control
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _movement;
        private AnimationControl _animationControl;
        private PlayerFight _playerAttack;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _animationControl = GetComponent<AnimationControl>();
            _playerAttack = GetComponent<PlayerFight>();
        }

        private void OnMove(InputValue value)
        {
            Vector2 inputValue = value.Get<Vector2>();

            _movement.moveInput = inputValue;
            _animationControl.UpdateMoveInput(inputValue);
        }

        private void OnAttack(InputValue value)
        {
             AttackType weaponType = _playerAttack.Attack();

            _animationControl.Attack(weaponType);
        }
    }
}