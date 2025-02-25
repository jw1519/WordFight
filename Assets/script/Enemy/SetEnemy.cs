using System;
using UnityEngine;
using static Enemy;

public class SetEnemy : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer actionRenderer;
    Player player;
    public SetEnemyUI enemyUI;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        enemyUI = GetComponent<SetEnemyUI>();
        SelectNextAction();
    }

    public void SelectNextAction()
    {
        EnemyAction action = GetRandomEnumValue<EnemyAction>();
        enemy.actionForThisTurn = action;

        switch (enemy.actionForThisTurn)
        {
            case EnemyAction.Attack:
                actionRenderer.sprite = enemy.attackSprite;
                return;

            case EnemyAction.Defend:
                actionRenderer.sprite = enemy.defenceSprite;
                return;

            case EnemyAction.Heal:
                if (enemy.health == enemy.maxHealth)
                {
                    SelectNextAction();
                    return;
                }
                actionRenderer.sprite = enemy.abilitySprite;
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
    public void EndTurn()
    {
        SelectNextAction();
        GameManager.instance.BeginTurn();
    }

}
