using UnityEngine.SceneManagement;

public class GameWonPanel : BasePanel
{
    public void Awake()
    {
        OpenPanel();
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
