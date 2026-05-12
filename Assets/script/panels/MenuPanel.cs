using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame()
    {
        Debug.Log("Resume saved game");
    }
    public void OpenSettings()
    {
        Debug.Log("Open settings");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
