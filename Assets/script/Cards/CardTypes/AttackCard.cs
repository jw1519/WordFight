using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Attack Card")]
public class AttackCard : Card, ICard
{
    private void OnEnable()
    {
        cardType = CardType.Attack;
    }
    public void Play()
    {
        SetEnemy setEnemy = FindFirstObjectByType<SetEnemy>();
        Enemy enemy = FindFirstObjectByType<Enemy>();
        if (enemy != null)
        {
            EventQueue.EnqueueEvent(new PlayerAttackEvent(enemy, value));
            setEnemy.gameObject.GetComponent<SetEnemyUI>().UpdateHealth(enemy);
        }
    }
}
