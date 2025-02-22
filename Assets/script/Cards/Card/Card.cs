using UnityEngine;
public abstract class Card : ScriptableObject
{
    public string letter;
    public int value;
    [HideInInspector] public CardType cardType;

    public enum CardType
    {
        Attack,
        Defence,
        Ability
    }
}
