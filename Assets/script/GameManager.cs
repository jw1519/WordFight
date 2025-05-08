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
    ShopPanel shopPanel;

    BasePlayer player;
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
            else if (panel.GetComponent<ShopPanel>() != null)
            {
                shopPanel = panel.GetComponent<ShopPanel>();
            }
        }
        NewGame();
    }
    public void NewGame()
    {
        //close panels
        foreach (BasePanel panel in UIManager.instance.panels)
        {
            if (panel.GetComponent<DifficultyPanel>() != null)
            {
                panel.GetComponent<DifficultyPanel>().gameObject.SetActive(true);
            }
            else
            {
                panel.gameObject.SetActive(false);
            }
        }
        //update player health
        player.health = player.maxHealth;
        player.playerUI.UpdatePlayerHealth(player);

        FindFirstObjectByType<ActionScrollRect>().ClearActions();
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
    }
    public void GameWon()
    {
        shopPanel.OpenPanel();
    }
}
