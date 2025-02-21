using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 30;
    public int maxHealth = 30;
    public int defence;

    public SetPlayerUI playerUI;

    public void Awake()
    {
        playerUI = GetComponent<SetPlayerUI>();
        playerUI.UpdatePlayerHealth(this);
    }
    public void RemoveDecorator()
    {
        GetComponent<AbilityManager>().RemoveDecorator("Strength");
        GetComponent<AbilityManager>().RemoveDecorator("Shield");
        defence = 0;
        EventQueue.EnqueueEvent(new PlayerDefenceEvent(this, defence));
    }
    public void TakeDamage(int damageTaken)
    {
        if (defence > 0)
        {
            damageTaken = damageTaken - defence;
        }
        if (health - damageTaken > 0)
        {
            health = health - damageTaken;
        }
        else
        {
            health = 0;
            GameManager.instance.Gameover();
        }
        playerUI.UpdatePlayerHealth(this);
    }
}
