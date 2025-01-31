using TMPro;
using UnityEngine;

public class SetHealth : MonoBehaviour
{
    public static SetHealth instance;
    public TextMeshProUGUI playerHealthtext;
    public TextMeshProUGUI enemyHealthtext;

    private Player player;
    private SetEnemy enemy;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<SetEnemy>();
        playerHealthtext.SetText(player.maxHealth + "/" + player.maxHealth);
        enemyHealthtext.SetText(enemy.enemy.maxHealth + "/" + enemy.enemy.maxHealth);
    }

    public void UpdatePlayerHealth()
    {
        playerHealthtext.SetText(player.health.ToString() + "/" + player.maxHealth);
        if (player.health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
    public void UpdateEnemyHealth()
    {
        enemyHealthtext.SetText(enemy.enemy.health.ToString() + "/" + enemy.enemy.maxHealth);
        if (enemy.enemy.health <= 0)
        {
            Debug.Log("you've won");
        }
    }
}
