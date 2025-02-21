using System;
using UnityEngine;
using static Enemy;

public class SetEnemy : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer actionrenderer;
    Player player;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        SelectNextAction();
    }

    public void SelectNextAction()
    {
        EnemyAction action = GetRandomEnumValue<EnemyAction>();
        enemy.actionForThisTurn = action;

        switch (enemy.actionForThisTurn)
        {
            case EnemyAction.Attack:
                actionrenderer.sprite = enemy.attackSprite;
                return;

            case EnemyAction.Defend:
                actionrenderer.sprite = enemy.defenceSprite;
                return;

            case EnemyAction.Heal:
                if (enemy.health == enemy.maxHealth)
                {
                    SelectNextAction();
                    return;
                }
                actionrenderer.sprite = enemy.abilitySprite;
                return;
        }  
    }
    public EnemyAction GetRandomEnumValue<Action>()
    {
        Array enumvalues = Enum.GetValues(typeof(EnemyAction)); // gets all posable values for the enum
        return (EnemyAction)enumvalues.GetValue(UnityEngine.Random.Range(0, enumvalues.Length)); //randomly selcts on of the actions from the enum and returns it
    }
    public void StartTurn()
    {
        
        enemy.defence = 0;
        switch (enemy.actionForThisTurn)
        {
            case EnemyAction.Attack:
                EventQueue.EnqueueEvent(new EnemyAttackEvent(player, enemy.damage));
                EndTurn();
                return;

            case EnemyAction.Defend:
                EventQueue.EnqueueEvent(new EnemyDefenceEvent(enemy, enemy.defenceAmount));
                GetComponent<SetEnemyUI>().UpdateDefence(enemy.defenceAmount);
                EndTurn();
                return;

            case EnemyAction.Heal:
                EventQueue.EnqueueEvent(new EnemyHealEvent(enemy, enemy.healAmount, enemy.health));
                EndTurn();
                return;
        }
    }
    public void TakeDamnage(int damageTaken)
    {
        if (enemy.defence > 0)
        {
            damageTaken = damageTaken - enemy.defence;
        }
        if (enemy.health - damageTaken > 0)
        {
            enemy.health = enemy.health - damageTaken;
        }
        else
        {
            enemy.health = 0;
            GameManager.instance.GameWon();
        }
        GetComponent<SetEnemyUI>().UpdateHealth(enemy);
    }
    public void EndTurn()
    {
        SelectNextAction();
        GameManager.instance.BeginTurn();
    }

}
