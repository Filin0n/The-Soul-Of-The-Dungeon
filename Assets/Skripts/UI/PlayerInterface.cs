using UnityEngine;
using UnityEngine.UI;

namespace SOD.UI
{
    public class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private Slider _staminaBar;
        [SerializeField] private Slider _halthBar;

        public void UpdateStamina(float value)
        {
            _staminaBar.value = value;
        } 
        
        public void UpdateHalth(float value)
        {
            _halthBar.value = value;
        }
    }
}