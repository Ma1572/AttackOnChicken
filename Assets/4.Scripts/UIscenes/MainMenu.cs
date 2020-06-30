using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   private GameManager _gameManager;

   private void Start()
   {
      SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive).completed += operation =>
         {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            GetComponent<Settings>().Setup();
            transform.GetChild(0).gameObject.SetActive(false);
         };
   }
   
   public void StartGame()
   {
      _gameManager = FindObjectOfType<GameManager>();
      _gameManager.StartGame();
      SceneManager.UnloadSceneAsync(0);
   }
}
