using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string levelToLoad = "Level1";

    public void SelectLevel(string levelname)
    {
        levelToLoad = levelname;
        SceneManager.LoadScene(levelToLoad);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
