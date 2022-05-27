using UnityEngine;

namespace SOD.Fight
{ 
    public class EnemyHP : MonoBehaviour
    {
        [SerializeField] private int _maxHP = 5;
        [SerializeField] private int _currentHP;

        private void Awake()
        {
            _currentHP = _maxHP;
        }

        public void TakeDamage(int damage)
        {
            _currentHP -= damage;

            if (_currentHP <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Die: " + gameObject.name);
        }
    }
}