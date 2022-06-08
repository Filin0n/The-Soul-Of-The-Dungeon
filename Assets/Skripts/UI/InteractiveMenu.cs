using UnityEngine;
using TMPro;

namespace SOD.UI
{ 
    public class InteractiveMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _interactiveMenu;
        [SerializeField] private TMP_Text _text;

        public void ActivateMenu(string text)
        {
            _interactiveMenu.SetActive(true);
            _text.text = text;
        }

        public void DeactivateMenu()
        {
            _interactiveMenu.SetActive(false);
        }
    }
}
