
public class DefenceStrategy : IActionStrategy
{
    public void Action(Enemy enemy)
    {
        enemy.defence = enemy.defenceAmount;
    }
}
