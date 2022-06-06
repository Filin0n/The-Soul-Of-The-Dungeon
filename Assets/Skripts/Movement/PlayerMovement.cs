using UnityEngine;


namespace SOD.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speedMove = 5f;
        [SerializeField] private float _gravityForce = 20f;
        [SerializeField] private float _dashDistance;

        private CharacterController _characterController;
        private float _currentGravityForce;

        private Vector2 _moveInput;
        private Vector3 _anchorPosition;

        public Vector2 MoveInput { set { _moveInput = value; } }
        public Vector3 AnchorPosition { set { _anchorPosition = value; } }

        public bool IsCanMove = true;

        private void Awake()
        { 
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            PlayerMove();
            if(IsCanMove) Rotation();
            Gravity();
        }

        private void PlayerMove()
        {
            Vector3 moveVector = Vector3.zero;

            moveVector.x = _moveInput.x * _speedMove;
            moveVector.z = _moveInput.y * _speedMove;
            moveVector.y = _currentGravityForce;

            _characterController.Move(moveVector * Time.deltaTime);
        }

        public void Dash()
        {
            Vector3 DashVector = Vector3.zero;

            DashVector.x = _moveInput.x * _dashDistance;
            DashVector.z = _moveInput.y * _dashDistance;

            _characterController.Move(DashVector);
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

        private void Rotation()
        {
            transform.LookAt(_anchorPosition);
        }
    }
}