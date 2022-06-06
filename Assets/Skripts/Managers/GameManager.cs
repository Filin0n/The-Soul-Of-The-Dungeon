using UnityEngine;
using UnityEngine.SceneManagement;
using SOD.Interactive;
using System.Collections.Generic;
using Cinemachine;

namespace SOD.Managers
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        private static int _currentBonfireID = 0;

        private GameObject _player;


        public int CurrentBonfireID
        {
            set
            {
                _currentBonfireID = value;
            }
        }


        private void Awake()
        {
            PlayerRebirth();
            Debug.Log("Current Bonfire ID: " + _currentBonfireID);
        }

        private void PlayerRebirth()
        {
            Bonfire[] bonfiers  = FindObjectsOfType<Bonfire>();

            Vector3 currentSpawnPosition = Vector3.zero;

            foreach (Bonfire fire in bonfiers)
            {
                if (fire.BonfireID == _currentBonfireID)
                {
                    currentSpawnPosition = fire.transform.position;
                }
            }

            _player = Instantiate(_playerPrefab, currentSpawnPosition, Quaternion.identity);
            _virtualCamera.Follow = _player.transform;
        }

        public void PlayerIsDead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("You are dead");
        }
    }
}