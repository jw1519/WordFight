using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;
    private Dictionary<string, BaseAbilityDecorator> activeDecorators;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        activeDecorators = new Dictionary<string, BaseAbilityDecorator>();
    }
    public void ApplyDecorator(string key, BaseAbilityDecorator decorator)
    {
        if (!activeDecorators.ContainsKey(key))
        {
            decorator.Apply(gameObject);
            activeDecorators[key] = decorator;
        }
    }

    public void RemoveDecorator(string key)
    {
        if (activeDecorators.ContainsKey(key))
        {
            activeDecorators[key].Remove(gameObject); // Call the specific decorator's Remove method

            activeDecorators.Remove(key); // Remove from active decorators
        }
    }
    public void ApplyDefence()
    {
        ApplyDecorator("Shield", new ShieldDecorator(gameObject));
    }
}
