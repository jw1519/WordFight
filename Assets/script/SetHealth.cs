using TMPro;
using UnityEngine;

public class SetPlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHealthtext;

    public void UpdatePlayerHealth(Player player)
    {
        playerHealthtext.SetText(player.health.ToString() + "/" + player.maxHealth);
        if (player.health <= 0)
        {
            Debug.Log("GameOver");
            GameManager.instance.Gameover();
        }
    }
}
