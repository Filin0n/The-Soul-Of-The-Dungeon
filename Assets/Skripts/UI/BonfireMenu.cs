using UnityEngine;

namespace SOD.UI
{
    public class BonfireMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _bonfireMenu;

        public bool BonfireMenuIsActive => _bonfireMenu.activeSelf;


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