using UnityEngine;
public abstract class Card : ScriptableObject
{
    public string letter;
    public int value;
    public bool isVowel;
    [HideInInspector] public CardType cardType;

    public enum CardType
    {
        Attack,
        Defence,
        Ability
    }
}
