using UnityEngine;
using SOD.UI;

namespace SOD.CycleOfDeath
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private int _bonfireID = 0;

        private UIInteractive _uIInteractive;

        public int BonfireID => _bonfireID;

        private void Awake()
        {
            _uIInteractive = FindObjectOfType<UIInteractive>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _uIInteractive.EnterBonfireZone(_bonfireID);
        }

        private void OnTriggerExit(Collider other)
        {
            _uIInteractive.ExitBonfireZone();
        }
    }
}