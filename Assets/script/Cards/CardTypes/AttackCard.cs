using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Attack Card")]
public class AttackCard : Card
{
    private void Awake()
    {
        cardType = CardType.Attack;
        defence = 0;
    }
    public override void Use()
    {
        Enemy enemy = FindFirstObjectByType<Enemy>();
        if (enemy != null)
        {
            if (enemy.defence == 0)
            {
                enemy.health = enemy.health - damage;
            }
            else if (enemy.defence - damage >= 0)
            {
                enemy.defence = enemy.defence - damage;
            }
            else
            {
                int damageTaken = damage - enemy.defence;
                enemy.defence = 0;
                enemy.health = enemy.health - damageTaken;
            }
        }
    }
}
