using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string letter;
    public int damage;
    public int defence;
    public CardType cardType;
    public enum CardType
    {
        Attack,
        Defence,
        Ability
    }
    public virtual void Use()
    {

    }
}
