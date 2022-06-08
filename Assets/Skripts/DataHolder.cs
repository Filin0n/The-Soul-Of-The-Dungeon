using UnityEngine;
using SOD.UI;

public class DataHolder : MonoBehaviour
{
    private PlayerInterface _playerInterface;

    private static int _currentBonfireID = 0;
    private static bool _isRelaxByBonfire;
    
    private static int _currentCountOfSouls;
    private static int _countOfLostSouls;
    private static Vector3 _lostSoulsPosition;

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
    public int CurrentCountOfSouls
    {
        get { return _currentCountOfSouls; }
        set 
        {
            _currentCountOfSouls = value;
            UpdateCurrentCountOfSoulInUI();
        }
    }
    public int CountOfLostSouls
    {
        get { return _countOfLostSouls; }

        set { _countOfLostSouls = value; }
    }
    public Vector3 LostSoulsPosition
    {
        get { return _lostSoulsPosition; }

        set { _lostSoulsPosition = value; }
    }

    private void Awake()
    { 
        _playerInterface = FindObjectOfType<PlayerInterface>();
        UpdateCurrentCountOfSoulInUI();
    }

    private void UpdateCurrentCountOfSoulInUI()
    {
        _playerInterface.UpdateNumberOfSouls(_currentCountOfSouls);
    }

    public void PlayerIsDie(Vector3 diePosition)
    {
        LostSoulsPosition = diePosition;
        CountOfLostSouls = CurrentCountOfSouls;
        CurrentCountOfSouls = 0;
    }
}
