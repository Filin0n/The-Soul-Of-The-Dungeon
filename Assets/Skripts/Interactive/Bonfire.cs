using UnityEngine;

namespace SOD.Interactive
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private int _bonfireID = 0;

        public int BonfireID => _bonfireID;
    }
}