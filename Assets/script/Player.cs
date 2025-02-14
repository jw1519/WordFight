using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int health = 30;
    public int maxHealth = 30;
    public int defence;

    private void Awake()
    {
        instance = this;
    }
    public void RemoveDecorator()
    {
        GetComponent<AbilityManager>().RemoveDecorator("Shield");
        GetComponent<AbilityManager>().RemoveDecorator("Strength");
        defence = 0;
    }
}
