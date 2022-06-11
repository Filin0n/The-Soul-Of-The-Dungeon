using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Cinemachine;

namespace SOD.CycleOfDeath
{
    public class CycleOfDeathManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _lostSoulPrefab;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private DataHolder _dataHolder;
        private static GameObject _player;

        public static GameObject Player => _player;
    
        private void Awake()
        {
            _dataHolder = FindObjectOfType<DataHolder>();
            SpawnPlayer(FindSpawnPosition());
            MoveSoulsToThePlaceOfDeath();
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
                if (fire.BonfireID == _dataHolder.CurrentBonfireID)
                {
                    currentSpawnPosition = fire.transform.position;
                }
            }

            return currentSpawnPosition;
        }

        private void MoveSoulsToThePlaceOfDeath()
        {
            int countOfLostSouls = _dataHolder.CountOfLostSouls;

            if (countOfLostSouls != 0)
            {
                Instantiate(_lostSoulPrefab, _dataHolder.LostSoulsPosition,Quaternion.identity);
            }
        }

        public void RelaxByBonfire(int bonfireID)
        {
            _dataHolder.CurrentBonfireID = bonfireID;
            _dataHolder.IsRelaxByBonfire = true;
            _dataHolder.CountOfLostSouls = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void PlayerIsDead(Vector3 diePosition)
        {
            _dataHolder.PlayerIsDie(diePosition);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void PickUpLostSouls()
        {
            _dataHolder.CurrentCountOfSouls += _dataHolder.CountOfLostSouls;
        }
    }
}