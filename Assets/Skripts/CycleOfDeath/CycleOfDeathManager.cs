using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Cinemachine;

namespace SOD.CycleOfDeath
{
    public class CycleOfDeathManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        private static int _currentBonfireID = 0;

        private GameObject _player;

        public GameObject Player => _player;

        private void Awake()
        {
            SpawnPlayer(FindSpawnPosition());
        }

        private void SpawnPlayer(Vector3 spawnPosition)
        {
            _player = Instantiate(_playerPrefab, spawnPosition, Quaternion.identity);
            _virtualCamera.Follow = _player.transform;
        }

        private Vector3 FindSpawnPosition()
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

            return currentSpawnPosition;
        }

        public void RelaxByBonfire()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void PlayerIsDead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("You are dead");
        }

        public void SetCurrentBonfireID(int bonfireID)
        {
            _currentBonfireID = bonfireID;
        }
    }
}