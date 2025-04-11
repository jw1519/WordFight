using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanel : BasePanel
{
    public static int amountOfWordsUsed;
    public TextMeshProUGUI text;
    public override void Awake()
    {
        base.Awake();
        ClosePanel();
    }
    public void SetStats()
    {
        text.text = "Amount Of Words Used: " + amountOfWordsUsed.ToString();
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
