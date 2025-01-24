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
    }
    public void UpdateEnemyHealth()
    {
        enemyHealthtext.SetText(enemy.enemy.health.ToString() + "/" + enemy.enemy.maxHealth);
    }
}
