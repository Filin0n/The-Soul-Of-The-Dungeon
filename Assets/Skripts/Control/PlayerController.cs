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
        //Тестовое поле
        [SerializeField] private int _changeWeaponId;

        private PlayerMovement _movement;
        private AnimationControl _animationControl;
        private PlayerFight _playerFight;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _animationControl = GetComponent<AnimationControl>();
            _playerFight = GetComponent<PlayerFight>();
        }

        private void OnMove(InputValue value)
        {
            Vector2 inputValue = value.Get<Vector2>();

            _movement.MoveInput = inputValue;
            _animationControl.UpdateMoveInput(inputValue);
        }

        private void OnDash(InputValue value)
        {
            _movement.Dash();
        }

        private void OnAttack(InputValue value)
        {
             AttackType weaponType = _playerFight.GetAttackType();
            _animationControl.Attack(weaponType);
        }

        //тестовое действие
        private void OnChangeWeapon(InputValue value)
        {

            _playerFight.ChaingeWeapon(_changeWeaponId);

            Debug.Log("Change weapon");
        }
    }
}