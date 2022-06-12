using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int _maxHP = 5;
    [SerializeField] private int _currentHP;
    [SerializeField] private int _countOfSouls;

    private DataHolder _dataHolder;


    private void Awake()
    {
        _currentHP = _maxHP;
        _dataHolder = FindObjectOfType<DataHolder>();
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
        _dataHolder.CurrentCountOfSouls += _countOfSouls;
        Destroy(gameObject);
    }
}
