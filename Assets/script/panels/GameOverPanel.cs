using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanel : BasePanel
{
    public TextMeshProUGUI wordsUsedText;

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
