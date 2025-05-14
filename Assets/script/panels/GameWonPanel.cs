using TMPro;
using UnityEngine;

public class GameWonPanel : BasePanel
{
    public static int amountOfWordsUsed;
    public TextMeshProUGUI goldEarnedText;
    Enemy enemy;
    Player player;
    BasePanel shopPanel;

    private void Start()
    {
        enemy = FindAnyObjectByType<SetEnemy>().enemy;
        player = FindAnyObjectByType<Player>();
        shopPanel = UIManager.instance.GetPanel("ShopPanel");
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
