using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 30;
    public int maxHealth = 30;
    int defence = 0;

    SetPlayerUI playerUI;

    public void Awake()
    {
        playerUI = GetComponent<SetPlayerUI>();
    }
    public void RemoveDecorator()
    {
        GetComponent<AbilityManager>().RemoveDecorator("Shield");
        defence = 0;
        SetDefence(defence);

        GetComponent<AbilityManager>().RemoveDecorator("Strength");
    }
    public void SetDefence(int value)
    {
        defence = defence + value;
        playerUI.UpdateDefence(defence);
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
