
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
    public SetEnemyUI UI;
    public int healAmount;

    public EnemyHealEvent(Enemy target, SetEnemyUI ui)
    {
        Target = target;
        UI = ui;
        healAmount = target.healAmount;
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
