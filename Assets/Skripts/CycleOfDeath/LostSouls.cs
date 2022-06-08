using UnityEngine;

namespace SOD.CycleOfDeath
{
    public class LostSouls : MonoBehaviour
    {
        private CycleOfDeathManager _cycleOfDeathManager;

        private void Awake()
        {
            _cycleOfDeathManager = FindObjectOfType<CycleOfDeathManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _cycleOfDeathManager.PickUpLostSouls();
            Destroy(gameObject);
        }
    }
}