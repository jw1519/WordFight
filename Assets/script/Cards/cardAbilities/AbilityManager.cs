using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;
    private Dictionary<string, BaseAbilityDecorator> activeDecorators;
    int defence;
    bool shieldActive;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        activeDecorators = new Dictionary<string, BaseAbilityDecorator>();
        shieldActive = false;
    }
    public void ApplyDecorator(string key, BaseAbilityDecorator decorator)
    {
        if (!activeDecorators.ContainsKey(key))
        {
            decorator.Apply(gameObject);
            activeDecorators[key] = decorator;

            if (key == "Shield")
            {
                shieldActive = true;
            }
            if (key == "Strength")
            {

            }
        }
    }

    public void RemoveDecorator(string key)
    {
        if (activeDecorators.ContainsKey(key))
        {
            activeDecorators[key].Remove(gameObject); // Call the specific decorator's Remove method

            if (key == "Shield")
            {
                shieldActive = false;
            }
            if (key == "Strength")
            {

            }

            activeDecorators.Remove(key); // Remove from active decorators
        }
    }
    public void ApplyDefence()
    {
        ApplyDecorator("Shield", new ShieldDecorator(gameObject));
    }
}
