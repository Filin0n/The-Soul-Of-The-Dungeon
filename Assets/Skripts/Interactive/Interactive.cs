using UnityEngine;
using SOD.Managers;

namespace SOD.Interactive
{
    public class Interactive : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bonfire bonfire))
            {
                FindObjectOfType<GameManager>().CurrentBonfireID = bonfire.BonfireID;

                Debug.Log("BonfireID: " + bonfire.BonfireID);
            }
        }
    }
}