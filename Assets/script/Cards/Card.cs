using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string letter;
    public int damageOrDefence;
    public CardType cardType;
    public enum CardType
    {
        Attack,
        Defence,
        Ability
    }
}
