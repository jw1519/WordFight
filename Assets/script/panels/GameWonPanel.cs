using UnityEngine.SceneManagement;

public class GameWonPanel : BasePanel
{
    public override void Awake()
    {
        base.Awake();
        ClosePanel();
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
