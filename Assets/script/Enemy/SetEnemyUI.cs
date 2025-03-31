using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetEnemyUI : MonoBehaviour
{
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI healthText;
    public Slider enemyHealthbar;

    public void UpdateDefence(int defence)
    {
        defenceText.text = defence.ToString();
    }
    public void UpdateHealth(Enemy enemy)
    {
        healthText.text = enemy.health + "/" + enemy.maxHealth;
        enemyHealthbar.maxValue = enemy.maxHealth;
        enemyHealthbar.value = enemy.health;
    }
}
