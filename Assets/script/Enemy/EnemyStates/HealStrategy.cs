
public class HealStrategy : IActionStrategy
{
    public void Action(Enemy enemy)
    {
        if (enemy.health + enemy.healAmount <= enemy.maxHealth)
        {
            enemy.health += enemy.healAmount;
        }
        else
        {
            enemy.health = enemy.maxHealth;
        }
    }
}
