using UnityEngine;

namespace SOD.Fight
{ 
    public class HP : MonoBehaviour
    {
        [SerializeField] private int _maxHP = 5;

        private int _currentHP;

        private void Awake()
        {
            _currentHP = _maxHP;
        }

        public void DamageDiller(int damage)
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