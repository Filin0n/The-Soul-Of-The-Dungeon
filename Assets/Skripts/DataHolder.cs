using UnityEngine;

public class DataHolder : MonoBehaviour
{
    private static int _currentBonfireID = 0;
    private static bool _isRelaxByBonfire;

    public int CurrentBonfireID 
    {
        get { return _currentBonfireID;}

        set { _currentBonfireID = value;}
    }

    public bool IsRelaxByBonfire
    {
        get { return _isRelaxByBonfire; }

        set { _isRelaxByBonfire = value; }
    }
}
