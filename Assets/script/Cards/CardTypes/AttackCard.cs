using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Attack Card")]
public class AttackCard : Card
{
    private void Awake()
    {
        cardType = CardType.Attack;
    }
    public override void Use()
    {
        SetEnemy setEnemy = FindFirstObjectByType<SetEnemy>();
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
