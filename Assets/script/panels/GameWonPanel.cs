using TMPro;

public class GameWonPanel : BasePanel
{
    public static int amountOfWordsUsed;
    public TextMeshProUGUI goldEarnedText;
    Enemy enemy;
    ShopPanel shopPanel;
    public override void Awake()
    {
        base.Awake();
        enemy = FindAnyObjectByType<SetEnemy>().enemy;
        shopPanel = FindAnyObjectByType<ShopPanel>();
        ClosePanel();
    }
    public void SetStats()
    {
        goldEarnedText.text = "Gold Earned: " + enemy.goldEarnedOnDefeat.ToString();
    }
    public void Continue()
    {
        shopPanel.OpenPanel();
        ClosePanel();
    }
}
