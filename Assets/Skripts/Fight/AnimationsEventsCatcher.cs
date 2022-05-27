using UnityEngine;
using SOD.Fight;


public class AnimationsEventsCatcher : MonoBehaviour
{
    [SerializeField] private PlayerFight _playerFight;

    public void CanAttack()
    {
        _playerFight.SetIsCanHurt(true);
    }

    public void CantAttack()
    {
        _playerFight.SetIsCanHurt(false);
    }
}
