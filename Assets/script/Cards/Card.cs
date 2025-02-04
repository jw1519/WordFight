using UnityEngine;

public class Card : ScriptableObject, ICard
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
    public virtual void Play() { }

}
