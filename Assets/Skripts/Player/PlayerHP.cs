using UnityEngine;
using SOD.CycleOfDeath;
using SOD.UI;


public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _maxHP = 5;
    [SerializeField] private int _currentHP;

    private CycleOfDeathManager _gameManager;
    private PlayerInterface _playerInterface;

    private void Awake()
    {
        _playerInterface = FindObjectOfType<PlayerInterface>();
        _currentHP = _maxHP;
        UpdateHalth();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<CycleOfDeathManager>();
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        UpdateHalth();

        if (_currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _gameManager.PlayerIsDead(transform.position);
    }

    private void UpdateHalth()
    {
        _playerInterface.UpdateHalth((float)_currentHP / _maxHP);
    }
}