using System.Collections.Generic;
using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    private int boostMultiplier = 2;
    private GameObject cardManager;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject player)
    {
        base.Apply(player);
        if (cardManager == null)
        {
            cardManager = Object.FindFirstObjectByType<GameManager>().gameObject;
        }
        foreach (GameObject gameObject in cardManager.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<AttackCard>() != null)
            {
                int value = gameObject.GetComponent<AttackCard>().value;
                value = value * boostMultiplier;
            }
        }
    }

    public void Remove(GameObject player)
    {
        base.Remove(player);
        foreach (GameObject gameObject in cardManager.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<AttackCard>() != null)
            {
                int value = gameObject.GetComponent<AttackCard>().value;
                value = value / boostMultiplier;
            }
        }
    }
}
