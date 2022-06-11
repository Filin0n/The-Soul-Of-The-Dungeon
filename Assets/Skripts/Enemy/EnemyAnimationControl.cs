using UnityEngine;

namespace SOD.EnemyAnimations
{
    public class EnemyAnimationControl : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetDirection(float horisontal, float vertical)
        {
            _animator.SetFloat("Horisontal", horisontal);
            _animator.SetFloat("Vertical", vertical);
        }
    }
}