using UnityEngine;

namespace SOD.UI
{
    public class BonfireMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _bonfireMenu;

        private void Awake()
        {
            DeactivateMenu();
        }

        public void ActivateMenu()
        {
            _bonfireMenu.SetActive(true);
        }

        public void DeactivateMenu()
        {
            _bonfireMenu.SetActive(false);
        }
    }
}