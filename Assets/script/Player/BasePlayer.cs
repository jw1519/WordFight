using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour, ITakeDamage, IHeal
{
    [SerializeField] public SetPlayerUI playerUI;

    [Header("PlayerStats")]
    public int health = 30;
    public int maxHealth = 30;
    public int defence;
    public int gold;
    
    [Header("PlayerItems")]
    public List <BaseItem> items;
    public int maxItems;
    public Transform itemParent;

    public virtual void Awake()
    {
        playerUI = GetComponent<SetPlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
            playerUI.UpdateItemsText(items.Count, maxItems);
        }
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
        //check for defences
        if (defence > 0)
        {
            if (defence >= damageTaken)
            {
                defence = defence - damageTaken;
                damageTaken = 0;
            }
            else
            {
                damageTaken = damageTaken - defence;
                defence = 0;
            }
        }
        if (health - damageTaken > 0)
        {
            health = health - damageTaken;
        }
        else
        {
            health = 0;
            GameManager.instance.Gameover();
            GameManager.instance.isGameDone = true;
        }
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
        }
    }
    public void Heal(int healAmount)
    {
        if (health + healAmount <= maxHealth)
        {
            health += healAmount;
        }
        else
        {
            health = maxHealth;
        }
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
        }
    }
    public void AddItem(BaseItem item)
    {
        item.transform.SetParent(itemParent);
        items.Add(item);
        playerUI.UpdateItemsText(items.Count, maxItems);
    }
    public void RemoveItem(BaseItem item)
    {
        items.Remove(item);
        playerUI.UpdateItemsText(items.Count, maxItems);
    }
}
