using UnityEngine;
using SOD.Enums;
using SOD.UI;

namespace SOD.Control
{
    public class StaminaControl : MonoBehaviour
    {
        [Header("��������� ������������")]
        [SerializeField] private float _maxStamina = 10f;
        [SerializeField] private float _currentStamina = 0;

        [Tooltip("�������� ������������� ������� � ��������� � �������, ��� 1 ��� 100% �� ������������� ������ �������")]
        [SerializeField] private float _recoveryRate = 0.25f;

        [Header("�������� ������������� ������������")]
        [Tooltip("�������� ����� ����")]
        [SerializeField] private float _deshRecoveryDelay = 1f;   
        [Tooltip("�������� ����� �����")]
        [SerializeField] private float _atackRecoveryDelay = 1.5f;


        [Header("����������� �������")]
        [SerializeField] private float _dashConsumption = 3;
        [SerializeField] private float _oneHandSword = 3;
        [SerializeField] private float _twoHandSword = 5;

        private bool _staminaCanRecover = true;

        private PlayerInterface _playerInterface;

        private void Awake()
        {
            _playerInterface = FindObjectOfType<PlayerInterface>();
        }

        private void Update()
        {
            if (_staminaCanRecover)
            {
                StaminaRegeneration();
            }
        }

        public bool Dash()
        {
            if(_currentStamina > 0)
            {
                _currentStamina -= _dashConsumption;
                Mathf.Clamp(_currentStamina, 0, Mathf.Infinity);
                _staminaCanRecover = false;
                UpdateStamina();
                Invoke("StaminaCanRecover", _deshRecoveryDelay);
                return true;
            }


            return false;
        }

        public bool Attack(WeaponType weaponType)
        {
            float attackConsumption = 0;

            switch (weaponType)
            {

                case WeaponType.OneHandSword:
                    attackConsumption = _oneHandSword;
                    break;
                case WeaponType.TwoHandSword:
                    attackConsumption = _twoHandSword;
                    break;
            }


            if (_currentStamina - (attackConsumption/2) > 0)
            {
                _currentStamina -= attackConsumption;
                Mathf.Clamp(_currentStamina, 0, Mathf.Infinity);
                UpdateStamina();
                _staminaCanRecover = false;
                Invoke("StaminaCanRecover", _atackRecoveryDelay);
                return true;
            }

            return false;
        }



        private void StaminaRegeneration()
        {
            _currentStamina += (_maxStamina * _recoveryRate) * Time.deltaTime;

            UpdateStamina();

            if (_currentStamina > _maxStamina)
            {
                _currentStamina = _maxStamina;
                _staminaCanRecover = false;
            }
        }

        private void StaminaCanRecover()
        {
            _staminaCanRecover = true;
        }

        private void UpdateStamina()
        {
            _playerInterface.UpdateStamina(_currentStamina / _maxStamina);
        }
    }
}