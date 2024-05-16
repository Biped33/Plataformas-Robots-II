using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
   
    public void QuitGame()
    {
        Debug.Log("You have quited the game (it doesnt show cus you are playing in editor)");
        Application.Quit();
    }

    // cambiar de escena
    public void ChangeToScene(string sceneName)
    {
        if (sceneName == "Level 1")
        {
            CreditsManager creditsManager = FindObjectOfType<CreditsManager>();

            if (creditsManager != null && creditsManager.creditsCount >= 1)
            {
                creditsManager.RemoveCredits(1);
                SceneManager.LoadScene(sceneName);
                Time.timeScale = 1;
            }
        }
        else if (sceneName != "Level 1")
        {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;

        }
    }

    public void ReloadScene()
    {

      
        CreditsManager creditsManager = FindObjectOfType<CreditsManager>();
        if (creditsManager != null && creditsManager.creditsCount >= 1)
        {
            creditsManager.RemoveCredits(1);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}