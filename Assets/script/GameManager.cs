/// <summary> this class manages the start and end of player turns, gameover and game won </summary>
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button submitButton;
    public Button endTurnButton;

    public GameObject gameOverPanel;
    public GameObject gameWonPanel;

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
    }

    public void BeginTurn()
    {
        player.RemoveDecorator();
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
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
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameWon()
    {
        gameWonPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
