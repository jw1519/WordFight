using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    public override void Awake()
    {
        base.Awake();
        ClosePanel();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
