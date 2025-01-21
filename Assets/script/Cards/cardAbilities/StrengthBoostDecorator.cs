using UnityEngine;

public class StrengthBoostDecorator : CardAbilitiy
{
    private int boostMultiplier = 2;
    public void Apply(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damageOrDefence = cards.card.damageOrDefence * boostMultiplier;
        }
        
    }

    public void Remove(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damageOrDefence = cards.card.damageOrDefence / boostMultiplier;
        }
    }
}
