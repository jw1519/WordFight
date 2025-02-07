using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Attack Card")]
public class AttackCard : Card, ICard
{
    private void Awake()
    {
        cardType = CardType.Attack;
    }
    public void Play()
    {
        SetEnemy setEnemy = GameObject.FindFirstObjectByType<SetEnemy>();
        Enemy enemy = setEnemy.enemy;
        if (enemy != null)
        {
            if (enemy.defence == 0)
            {
                enemy.health = enemy.health - value;
            }
            else if (enemy.defence - value >= 0)
            {
                enemy.defence = enemy.defence - value;
            }
            else
            {
                int damageTaken = value - enemy.defence;
                enemy.defence = 0;
                enemy.health = enemy.health - damageTaken;
            }
            SetHealth.instance.UpdateEnemyHealth();
        }
    }
}
