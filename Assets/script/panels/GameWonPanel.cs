using TMPro;

public class GameWonPanel : BasePanel
{
    public static int amountOfWordsUsed;
    public TextMeshProUGUI goldEarnedText;
    Enemy enemy;
    Player player;
    ShopPanel shopPanel;
    public override void Awake()
    {
        base.Awake();
        enemy = FindAnyObjectByType<SetEnemy>().enemy;
        shopPanel = FindAnyObjectByType<ShopPanel>();
        player = FindAnyObjectByType<Player>();
    }
    public void SetStats()
    {
        goldEarnedText.text = "Gold Earned: " + enemy.goldEarnedOnDefeat.ToString();
        player.gold += enemy.goldEarnedOnDefeat;
        player.playerUI.UpdateGoldText(player.gold);
    }
    public void Continue()
    {
        shopPanel.OpenPanel();
        ClosePanel();
    }
}
