using UnityEngine;
using TMPro;

public class SetEnemyUI : MonoBehaviour
{
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI healthText;

    public void UpdateDefence(int defence)
    {
        defenceText.text = defence.ToString();
    }
    public void UpdateHealth(Enemy enemy)
    {
        healthText.text = enemy.health + "/" + enemy.maxHealth;
    }
}
