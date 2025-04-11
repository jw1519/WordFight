/// <summary> this class manages the start and end of player turns, gameover and game won </summary>
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button submitButton;
    public Button endTurnButton;
    public int amountOfWordsUsed;

    GameOverPanel gameOverPanel;
    GameWonPanel gameWonPanel;

    Player player;
    SetEnemy enemy;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemy = FindObjectOfType<SetEnemy>();
        player = FindObjectOfType<Player>();

        foreach (BasePanel panel in UIManager.instance.panels)
        {
            if (panel.GetComponent<GameOverPanel>() != null)
            {
                gameOverPanel = panel.GetComponent<GameOverPanel>();
            }
            else if (panel.GetComponent<GameWonPanel>() != null)
            {
                gameWonPanel = panel.GetComponent<GameWonPanel>();
            }
        }
        amountOfWordsUsed = 0;
    }

    public void BeginTurn()
    {
        player.RemoveDecorator();
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
        EventQueue.instance.ResetProcessing();
    }
    public void EndTurn()
    {
        CardManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        enemy.StartTurn();
    }
    public void Gameover()
    {
        gameOverPanel.OpenPanel();
        gameOverPanel.SetStats();
        Time.timeScale = 0;
    }
    public void GameWon()
    {
        gameWonPanel.OpenPanel();
        gameWonPanel.SetStats();
        Time.timeScale = 0;
    }
}
