using UnityEngine;
using SOD.CycleOfDeath;

namespace SOD.Fight
{
    public class PlayerHP : MonoBehaviour
    {
        [SerializeField] private int _maxHP = 5;
        [SerializeField] private int _currentHP;

        private CycleOfDeathManager _gameManager;

        private void Awake()
        {
            _currentHP = _maxHP;
        }

        private void Start()
        {
            _gameManager = FindObjectOfType<CycleOfDeathManager>();
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
            _gameManager.PlayerIsDead();
        }
    }
}