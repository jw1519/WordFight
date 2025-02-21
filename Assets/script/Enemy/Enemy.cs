using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public EnemyAction actionForThisTurn;

    [Header("Stats")]
    public int health;
    public int damage;
    public int maxHealth;
    public int defence;
    public EnemyDifficulty difficulty;

    [Header("Ability amounts")]
    public int healAmount;
    public int defenceAmount;

    [Header("Action Sprites")]
    public Sprite attackSprite;
    public Sprite defenceSprite;
    public Sprite abilitySprite;

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
    private void Awake()
    {
        
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
            GameManager.instance.GameWon();
        }
    }
}
