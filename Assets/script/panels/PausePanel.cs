using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    private void Awake()
    {
        ClosePanel();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
