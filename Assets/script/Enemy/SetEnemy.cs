using System;
using UnityEngine;
using static Enemy;

public class SetEnemy : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer actionrenderer;
    private void Awake()
    {
        StartTurn();
    }

    public void StartTurn()
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
            case EnemyAction.UseAbility:
                actionrenderer.sprite = enemy.abilitySprite;
                return;
        }  
    }
    public EnemyAction GetRandomEnumValue<Action>()
    {
        Array enumvalues = Enum.GetValues(typeof(EnemyAction)); // gets all posable values for the enum
        return (EnemyAction)enumvalues.GetValue(UnityEngine.Random.Range(0, enumvalues.Length)); //randomly selcts on of the actions from the enum and returns it
    }
}
