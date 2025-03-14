
public class DifficultyPanel : BasePanel
{
    Enemy.EnemyDifficulty difficulty;
    SetDifficulty setDifficulty;

    public override void Awake()
    {
        base.Awake();
        setDifficulty = gameObject.GetComponent<SetDifficulty>();
    }
    public void Easy()
    {
        difficulty = Enemy.EnemyDifficulty.Easy;
        setDifficulty.SetUp(difficulty);
    }
    public void Medium()
    {
        difficulty = Enemy.EnemyDifficulty.Medium;
        setDifficulty.SetUp(difficulty);
    }
    public void Hard()
    {
        difficulty = Enemy.EnemyDifficulty.Hard;
        setDifficulty.SetUp(difficulty);
    }
}
