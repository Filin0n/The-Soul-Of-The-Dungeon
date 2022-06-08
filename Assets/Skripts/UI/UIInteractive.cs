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
        private DataHolder _dataHolder;

        private bool _canRest = false;
        private int _bonfireID;


        private void Awake()
        {
            _dataHolder = FindObjectOfType<DataHolder>();
            _cycleOfDeathManager = FindObjectOfType<CycleOfDeathManager>();

            _interactiveMenu = FindObjectOfType<InteractiveMenu>();
            _bonfireMenu = FindObjectOfType<BonfireMenu>();

            if (_dataHolder.IsRelaxByBonfire)
            {
                _bonfireMenu.ActivateMenu();
                PlayerControllSetActive(false);
                _interactiveMenu.DeactivateMenu();
            }
        }

        private void OnInteractive(InputValue value)
        {
            if (_canRest)
            {
                _cycleOfDeathManager.RelaxByBonfire(_bonfireID);
            }
        }

        private void OnExit(InputValue value)
        {
            ExitBonfireMenu();
        }

        private void ExitBonfireMenu()
        {
            _dataHolder.IsRelaxByBonfire = false;
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

            if (!_bonfireMenu.BonfireMenuIsActive)
            {
                _interactiveMenu.ActivateMenu("Отдохнуть");
            }
        }

        public void ExitBonfireZone()
        {
            _canRest = false;
            _interactiveMenu.DeactivateMenu();
        }
    }
}
