using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button submitButton;
    public Button endTurnButton;

    GameOverPanel gameOverPanel;
    GameWonPanel gameWonPanel;

    SetEnemy enemy;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemy = FindObjectOfType<SetEnemy>();
        gameOverPanel = FindAnyObjectByType<GameOverPanel>();
        gameWonPanel = FindAnyObjectByType<GameWonPanel>();
    }

    public void BeginTurn()
    {
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }
    public void EndTurn()
    {
        Player.instance.RemoveDecorator();
        CardManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        enemy.StartTurn();
    }
    public void Gameover()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameWon()
    {
        gameWonPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
