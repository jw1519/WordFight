using UnityEngine;
using TMPro;

public class ActionScrollRect : MonoBehaviour
{
    public static ActionScrollRect instance;
    public Transform actionTextContainer;
    public TextMeshProUGUI text;
    private void Awake()
    {
        instance = this;
    }
    public void AddText(TextMeshProUGUI text)
    {
        if (actionTextContainer.childCount >= 5)
        {
            Destroy(actionTextContainer.GetChild(0).gameObject);
        }
        Instantiate(text, actionTextContainer);
    }
    public void Display(GameEvent gameEvent)
    {
        if (gameEvent is PlayerAttackEvent playerAttack)
        {
            text.text = $"Player attacks {playerAttack.Target} for {playerAttack.Damage} damage";
            
        }
        else if (gameEvent is PlayerDefenceEvent playerDefence)
        {
            text.text = $"Player defends for {playerDefence.Defence} defence";
        }
        else if (gameEvent is PlayerHealEvent playerHeal)
        {
            text.text = $"Player healed for {playerHeal.HealAmount} health";
        }
        else if (gameEvent is EnemyAttackEvent enemyAttack)
        {
            text.text = $"Enemy attacks {enemyAttack.Target} for {enemyAttack.Damage} damage";
        }
        else if (gameEvent is EnemyDefenceEvent enemyDefence)
        {
            text.text = $"Enemy defends for {enemyDefence.Defence} defence";
        }
        else if (gameEvent is EnemyHealEvent enemyHeal)
        {
            text.text = $"Enemy Heals for {enemyHeal.healAmount} health";
        }
        AddText(text);
    }
    public void ClearActions()
    {
        int child = actionTextContainer.childCount;
        for (int i = 0; i < child; i++)
        {
            Destroy(actionTextContainer.GetChild(i).gameObject);
        }
    }
}
