using UnityEngine;
using SOD.Enums;

namespace SOD.Animations
{
    public class AnimationControl : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private Vector2 _moveInput;

        public void UpdateMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        private void Update()
        {
            UpdateAnimations();
        }

        private void UpdateAnimations()
        {
            float rotationY = transform.localRotation.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0, -rotationY, 0) * new Vector3(_moveInput.x, 0, _moveInput.y);

            _animator.SetFloat("Horisontal", moveDirection.x);
            _animator.SetFloat("Vertical", moveDirection.z);
        }

        public void Attack(AttackType weaponType)
        {
            _animator.SetTrigger("Attack");

            _animator.SetInteger("WeaponTypeInt", (int)weaponType);
            _animator.SetFloat("WeaponTypeFloat", (float)weaponType);
        }
    }
}