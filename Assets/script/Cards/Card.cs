using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string letter;
    public int damage;
    public int defence;
    public CardType cardType;

    [HideInInspector] public Player player;
    [HideInInspector] public AbilityManager abilityManager;
    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        abilityManager = player.GetComponent<AbilityManager>();
    }
    public enum CardType
    {
        Attack,
        Defence,
        Ability
    }
    public virtual void Use() { }
}
