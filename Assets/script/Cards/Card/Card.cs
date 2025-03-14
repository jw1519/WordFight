using UnityEngine;
public abstract class Card : ScriptableObject
{
    public string letter;
    public int value;
    public bool isVowel;
    public Sprite sprite;
    [HideInInspector] public CardType cardType;

    public enum CardType
    {
        Attack,
        Defence,
        Strength,
        Heal,
    }
}
