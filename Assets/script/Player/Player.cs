using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, IHeal
{
    public PlayerSO PlayerSO;
    public SetPlayerUI playerUI;

    public void Awake()
    {
        playerUI = GetComponent<SetPlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
        }
    }
    public void RemoveDecorator()
    {
        GetComponent<AbilityManager>().RemoveDecorator("Strength");
        GetComponent<AbilityManager>().RemoveDecorator("Shield");
        PlayerSO.defence = 0;
        EventQueue.EnqueueEvent(new PlayerDefenceEvent(this, PlayerSO.defence));
    }
    public void TakeDamage(int damageTaken)
    {
        //check for defences
        if (PlayerSO.defence > 0)
        {
            if (PlayerSO.defence >= damageTaken)
            {
                PlayerSO.defence = PlayerSO.defence - damageTaken;
                damageTaken = 0;
            }
            else
            {
                damageTaken = damageTaken - PlayerSO.defence;
                PlayerSO.defence = 0;
            }
        }
        if (PlayerSO.health - damageTaken > 0)
        {
            PlayerSO.health = PlayerSO.health - damageTaken;
        }
        else
        {
            PlayerSO.health = 0;
            GameManager.instance.Gameover();
        }
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
            playerUI.UpdateDefence(PlayerSO.defence);
        }
    }
    public void Heal(int healAmount)
    {
        if (PlayerSO.health + healAmount <= PlayerSO.maxHealth)
        {
            PlayerSO.health += healAmount;
        }
        else
        {
            PlayerSO.health = PlayerSO.maxHealth;
        }
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
        }
    }
}
