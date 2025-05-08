/// <summary> this class is a basic class for enemies scriptable objects</summary>
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject, ITakeDamage, IHeal
{
    public EnemyAction actionForThisTurn;

    [Header("Stats")]
    public int health;
    public int damage;
    public int maxHealth;
    public int defence;
    public EnemyDifficulty difficulty;
    public string weakness;

    [Header("Ability amounts")]
    public int healAmount;
    public int defenceAmount;

    [Header("Action Sprites")]
    public Sprite attackSprite;
    public Sprite defenceSprite;
    public Sprite abilitySprite;
    public Sprite enemySprite;

    [Header("Extra")]
    public int goldEarnedOnDefeat;

    public enum EnemyAction
    {
        Attack,
        Defend,
        Heal,
    }
    public enum EnemyDifficulty
    {
        Easy,
        Medium,
        Hard
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
            GameManager.instance.GameWon();
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
    }
}
