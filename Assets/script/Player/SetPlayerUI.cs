using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHealthtext;
    public TextMeshProUGUI defenceText;
    public Slider healthBar;

    public void UpdatePlayerHealth(BasePlayer player)
    {
        playerHealthtext.SetText(player.health.ToString() + "/" + player.maxHealth);
        healthBar.value = player.health;
        if (player.health <= 0)
        {
            Debug.Log("GameOver");
            GameManager.instance.Gameover();
        }
    }
    public void UpdateDefence(int defence)
    {
        defenceText.text = defence.ToString();
    }
}
