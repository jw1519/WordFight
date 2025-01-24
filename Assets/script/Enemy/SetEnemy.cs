using System;
using Unity.VisualScripting;
using UnityEngine;
using static Enemy;

public class SetEnemy : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer actionrenderer;
    private void Awake()
    {
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
        switch (enemy.actionForThisTurn)
        {
            case EnemyAction.Attack:
                if (Player.instance.health - enemy.damage <= 0)
                {
                    Debug.Log("game over");
                }
                else
                {
                    Player.instance.health = Player.instance.health - enemy.damage;
                }
                EndTurn();
                return;

            case EnemyAction.Defend:
                enemy.defence = enemy.defenceAmount;
                EndTurn();
                return;

            case EnemyAction.Heal:
                if (enemy.health + enemy.healAmount <= enemy.maxHealth)
                {
                    enemy.health = enemy.health + enemy.healAmount;
                }
                else
                {
                    enemy.health = enemy.maxHealth;
                }
                EndTurn();
                return;
        }
    }
    public void EndTurn()
    {
        SetHealth.instance.UpdatePlayerHealth();
        SelectNextAction();
        GameManager.instance.BeginTurn();
    }
}
