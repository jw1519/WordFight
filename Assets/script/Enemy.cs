using UnityEngine;

public class Enemy : ScriptableObject
{
    private int health;
    private int damage; 
    private int maxHealth;
    public Action actionForThisTurn;
    
    public Difficulty difficulty;
    private void Awake()
    {
       switch (difficulty)
        {
            case Difficulty.easy:
                health = 10;
                damage = 3;
                break;
            case Difficulty.medium:
                health = 20;
                damage = 5;
                break;
            case Difficulty.hard:
                health = 25;
                damage = 7;
                break;
        }
        maxHealth = health;
    }
    public enum Action
    {
        Attack,
        Defend,
        UseAbility,
    }

    public enum Difficulty
    {
        easy,
        medium,
        hard
    }
}
