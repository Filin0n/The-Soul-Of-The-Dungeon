using UnityEngine;
using SOD.CycleOfDeath;
using UnityEngine.InputSystem;
using SOD.Control;

namespace SOD.UI
{
    public class UIInteractive : MonoBehaviour
    {
        private CycleOfDeathManager _cycleOfDeathManager;
        private InteractiveMenu _interactiveMenu;
        private BonfireMenu _bonfireMenu;

        private bool _canRest = false;
        private int _bonfireID;


        private void Awake()
        {
            _interactiveMenu = FindObjectOfType<InteractiveMenu>();
            _cycleOfDeathManager = FindObjectOfType<CycleOfDeathManager>();
            _bonfireMenu = FindObjectOfType<BonfireMenu>();
        }

        private void OnInteractive(InputValue value)
        {
            if (_canRest)
            {
                Debug.Log("Rest");

                _cycleOfDeathManager.SetCurrentBonfireID(_bonfireID);
                _bonfireMenu.ActivateMenu();
                _canRest = false;
                PlayerControllSetActive(false);
            }
        }

        private void OnExit(InputValue value)
        {
            _bonfireMenu.DeactivateMenu();
            PlayerControllSetActive(true);
        }

        private void PlayerControllSetActive(bool active)
        {
            GameObject player = _cycleOfDeathManager.Player;

            player.GetComponent<PlayerInput>().enabled = active;
            player.GetComponent<Anchor>().enabled = active;
        }

        public void EnterBonfireZone(int bonfireID)
        {
            _canRest = true;
            _bonfireID = bonfireID;
            _interactiveMenu.ActivateMenu("Отдохнуть");
        }

        public void ExitBonfireZone()
        {
            _interactiveMenu.DeactivateMenu();
        }
    }
}
