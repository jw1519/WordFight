using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetHealth : MonoBehaviour
{
    public TextMeshProUGUI playerHealthtext;
    public TextMeshProUGUI enemyHealthtext;

    private Player player;
    private SetEnemy enemy;
    
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
