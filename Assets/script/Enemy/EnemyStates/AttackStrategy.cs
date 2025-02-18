using UnityEngine;

public class AttackStrategy : MonoBehaviour, IActionStrategy
{
    Player player;
    void Awake()
    {
        player = FindAnyObjectByType<Player>(); 
    }
    public void Action(Enemy enemy)
    {
        if (player != null)
        {
            if(player.health - enemy.damage > 0)
            {
                player.health -= enemy.damage;
            }
            else
            {
                player.health = 0;
            }
            SetHealth.instance.UpdatePlayerHealth();
        }
    }
}
