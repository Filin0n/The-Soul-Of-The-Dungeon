using UnityEngine;

namespace SOD.Core 
{
    public class TargetCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}