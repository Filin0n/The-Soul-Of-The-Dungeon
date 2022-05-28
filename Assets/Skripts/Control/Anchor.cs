using UnityEngine;
using UnityEngine.InputSystem;
using SOD.Movement;

namespace SOD.Control
{

    public class Anchor : MonoBehaviour
    {
        [SerializeField] private Transform _anchor;
        [SerializeField] private LayerMask _raycastlayerMask = (1 << 6);

        private Vector3 _anchorPosition;

        private PlayerMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            LookAtAnchorRaycast();
        }

        private void LookAtAnchorRaycast()
        {
            Vector2 inputMousePosition = Mouse.current.position.ReadValue();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(inputMousePosition);

            if (Physics.Raycast(ray, out hit, 100, _raycastlayerMask))
            {
                Vector3 hitPositon = hit.point;
                _anchorPosition = hitPositon;
            }

            _anchorPosition.y = transform.position.y;

            _anchor.position = _anchorPosition;
            _movement.AnchorPosition = _anchorPosition;
        }
    }
}
