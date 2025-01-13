using UnityEngine;

public class StrengthBoostDecorator : CardAbilitiy
{
    private int boostMultiplier = 2;
    public void Apply(GameObject gameObject)
    {
        foreach (SetCard cards in GameManager.instance.hand)
        {
            cards.card.damage = cards.card.damage * boostMultiplier;
        }
        
    }

    public void Remove(GameObject gameObject)
    {
        foreach (SetCard cards in GameManager.instance.hand)
        {
            cards.card.damage = cards.card.damage / boostMultiplier;
        }
    }
}
