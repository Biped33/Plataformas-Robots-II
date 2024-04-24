using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // sale del juego
    public void QuitGame()
    {
        Debug.Log("You have quited the game (it doesnt show cus you are playing in editor)");
        Application.Quit();
    }

    // cambiar de escena
    public void changeToScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}

