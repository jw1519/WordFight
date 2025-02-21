
public class EnemyAttackEvent : GameEvent
{
    public Player Target;
    public int Damage;

    public EnemyAttackEvent(Player target, int damage)
    {
        Target = target;
        Damage = damage;
    }
}
public class EnemyHealEvent : GameEvent
{
    public Enemy Target;
    public int healAmount;
    public int Health;

    public EnemyHealEvent(Enemy target, int heal, int health)
    {
        Target = target;
        healAmount = heal;
        Health = health;
    }
}
public class EnemyDefenceEvent : GameEvent
{
    public Enemy Target;
    public int Defence;

    public EnemyDefenceEvent(Enemy target, int defence)
    {
        Target = target;
        Defence = defence;
    }
}
