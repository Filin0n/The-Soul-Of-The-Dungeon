using UnityEngine;
using UnityEngine.InputSystem;

namespace SOD.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speedMove = 5f;
        [SerializeField] private float _gravityForce = 20f ;
        [SerializeField] private Transform  _iKMouseTarget;

        private float _currentGravityForce;
        private CharacterController _characterController;

        [SerializeField] private Vector3 _targetMousePosition;

        [HideInInspector] public Vector2 moveInput;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            LookAtMouseTargetIK();
            PlayerMove();
            Rotation();
            Gravity();
        }

        private void PlayerMove()
        {
            Vector3 moveVector = Vector3.zero;

            moveVector.x = moveInput.x * _speedMove;
            moveVector.z = moveInput.y * _speedMove;
            moveVector.y = _currentGravityForce;

            _characterController.Move(moveVector * Time.deltaTime);
        }

        private void Gravity()
        {
            if (!_characterController.isGrounded)
            {
                _currentGravityForce -= _gravityForce * Time.deltaTime;
            }
            else
            {
                _currentGravityForce = -1;
            }
        }

        private void LookAtMouseTargetIK()
        {
            Vector2 inputMousePosition = Mouse.current.position.ReadValue();
            Vector2 _skreenMousePosition = inputMousePosition - new Vector2(Screen.width / 2, Screen.height / 2);

            _targetMousePosition = transform.position + new Vector3(_skreenMousePosition.x, 0, _skreenMousePosition.y);

            if (_iKMouseTarget == null) return;

            _iKMouseTarget.transform.position = new Vector3 (_targetMousePosition.x, _iKMouseTarget.transform.position.y, _targetMousePosition.z);
        }

        private void Rotation()
        {
            Quaternion rotation = Quaternion.LookRotation(_targetMousePosition);
            transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
        }
    }
}