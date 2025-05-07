using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHealthtext;
    public TextMeshProUGUI defenceText;
    public Slider healthBar;

    public void UpdatePlayerHealth(Player player)
    {
        playerHealthtext.SetText(player.PlayerSO.health.ToString() + "/" + player.PlayerSO.maxHealth);
        healthBar.value = player.PlayerSO.health;
        if (player.PlayerSO.health <= 0)
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
