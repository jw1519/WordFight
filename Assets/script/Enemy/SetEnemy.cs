using System;
using TMPro;
using UnityEngine;
using static Enemy;

public class SetEnemy : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer actionRenderer;
    public TextMeshProUGUI actionText;
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
                actionText.text = enemy.damage.ToString();
                return;

            case EnemyAction.Defend:
                actionRenderer.sprite = enemy.defenceSprite;
                actionText.text = enemy.defenceAmount.ToString();
                return;

            case EnemyAction.Heal:
                if (enemy.health == enemy.maxHealth)
                {
                    SelectNextAction();
                    return;
                }
                actionRenderer.sprite = enemy.abilitySprite;
                actionText.text = enemy.healAmount.ToString();
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
                ActionScrollRect.instance.Display(new EnemyAttackEvent(player, enemy.damage));
                EndTurn();
                return;

            case EnemyAction.Defend:
                EventQueue.EnqueueEvent(new EnemyDefenceEvent(enemy, enemy.defenceAmount));
                ActionScrollRect.instance.Display(new EnemyDefenceEvent(enemy, enemy.defenceAmount));
                GetComponent<SetEnemyUI>().UpdateDefence(enemy.defenceAmount);
                EndTurn();
                return;

            case EnemyAction.Heal:
                EventQueue.EnqueueEvent(new EnemyHealEvent(enemy, enemyUI, enemy.healAmount, enemy.health));
                ActionScrollRect.instance.Display(new EnemyHealEvent(enemy, enemyUI, enemy.healAmount, enemy.health));
                EndTurn();
                return;
        }
    }
    public void EndTurn()
    {
        SelectNextAction();
        GameManager.instance.BeginTurn();
    }
    public void SetEnemySprite(Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
