public class PlayerAttackEvent : GameEvent
{
    public Enemy Target;
    public int Damage;
    public SetEnemyUI EnemyUI;

    public PlayerAttackEvent(Enemy target, int damage, SetEnemyUI enemyUI)
    {
        Target = target;
        Damage = damage;
        EnemyUI = enemyUI;
    }
}
public class PlayerDefenceEvent : GameEvent
{
    public Player Target;
    public int Defence;

    public PlayerDefenceEvent(Player target, int defence)
    {
        Target = target;
        Defence = defence;
    }
}
public class PlayerHealEvent : GameEvent
{
    public Player Target;
    public int HealAmount;

    public PlayerHealEvent(Player target, int healAmount)
    {
        Target = target;
        HealAmount = healAmount;
    }
}

