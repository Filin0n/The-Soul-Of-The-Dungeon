using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SOD.UI
{
    public class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private Slider _staminaBar;
        [SerializeField] private Slider _halthBar;
        [SerializeField] private TMP_Text _numberOfSouls;

        public void UpdateStamina(float value)
        {
            _staminaBar.value = value;
        } 
        
        public void UpdateHalth(float value)
        {
            _halthBar.value = value;
        }

        public void UpdateNumberOfSouls(int value)
        {
            _numberOfSouls.text = value.ToString();
        }
    }
}