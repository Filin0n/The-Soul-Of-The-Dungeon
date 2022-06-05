using UnityEngine;
using UnityEngine.SceneManagement;

namespace SOD.Managers
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        [SerializeField] private int test = 0;

        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void PlayerIsDead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("You are dead");
        }
    }
}