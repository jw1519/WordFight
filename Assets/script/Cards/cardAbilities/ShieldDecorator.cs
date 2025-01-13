using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDecorator : CardAbilitiy
{
    private GameObject shield;
    public void Apply(GameObject player)
    {
        if (shield == null)
        {
            shield = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }

    public void Remove(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
