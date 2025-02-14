using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int health = 30;
    public int maxHealth = 30;
    public int defence;

    public TextMeshProUGUI defenceText;

    private void Awake()
    {
        instance = this;
        defence = 0;
    }
    public void RemoveDecorator()
    {
        GetComponent<AbilityManager>().RemoveDecorator("Shield");
        defence = 0;
        SetDefence(defence);

        GetComponent<AbilityManager>().RemoveDecorator("Strength");
    }
    public void SetDefence(int value)
    {
        defence = defence + value;
        defenceText.text = value.ToString();
    }
}
