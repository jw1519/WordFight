using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    private int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject gameObject)
    {


    }

    public void Remove(GameObject gameObject)
    {

    }
}
