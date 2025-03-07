using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    private static Queue<GameEvent> eventQueue = new Queue<GameEvent>();
    private static bool isProcessing = false;
    public static EventQueue instance;

    public Transform actionTextContainer;
    public TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }

    public static void EnqueueEvent(GameEvent gameEvent)
    {
        eventQueue.Enqueue(gameEvent);
        if (!isProcessing)
        {
            isProcessing = true;
            instance.StartCoroutine(ProcessEvents());
        }
    }
    private static IEnumerator ProcessEvents()
    {
        while (eventQueue.Count > 0)
        {
            GameEvent gameEvent = eventQueue.Dequeue();
            yield return HandleEvent(gameEvent);
        }
        isProcessing = false;
    }

    private static IEnumerator HandleEvent(GameEvent gameEvent)
    {
        if (gameEvent is PlayerAttackEvent playerAttack)
        {
            playerAttack.Target.TakeDamage(playerAttack.Damage);
            playerAttack.EnemyUI.UpdateHealth(playerAttack.Target);
            yield return new WaitForSeconds(1); //do animation here
        }
        else if (gameEvent is PlayerDefenceEvent playerDefence)
        {
            playerDefence.Target.defence = playerDefence.Target.defence + playerDefence.Defence;
            playerDefence.Target.playerUI.UpdateDefence(playerDefence.Target.defence);

            yield return new WaitForSeconds(1); //do animation here
        }
        else if (gameEvent is EnemyAttackEvent enemyAttack)
        {
            enemyAttack.Target.TakeDamage(enemyAttack.Damage);
            yield return new WaitForSeconds(1); //do animation here
        }
        else if (gameEvent is EnemyDefenceEvent enemyDefence)
        {
            enemyDefence.Target.defence = enemyDefence.Target.defenceAmount;
            yield return new WaitForSeconds(1);
        }
        else if (gameEvent is EnemyHealEvent enemyHeal)
        {
            if (enemyHeal.Health + enemyHeal.healAmount <= enemyHeal.Target.maxHealth)
            {
                enemyHeal.Health += enemyHeal.healAmount;
            }
            else
            {
                enemyHeal.Health = enemyHeal.Target.maxHealth;
            }
            yield return new WaitForSeconds(1);

        }
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
        Instantiate(text, actionTextContainer);
    }
}
