using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : BasePanel
{
    public static GameOverPanel instance;

    [SerializeField] public int wordsUsed;
    public TextMeshProUGUI wordsUsedText;

    public void Awake()
    {
        instance = this;
        OpenPanel();
    }

    public void SetStats()
    {
        wordsUsedText.text = "Words used:" + wordsUsed;
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
