using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Dictionary<string, BaseAbilityDecorator> activeDecorators;
    // Start is called before the first frame update
    void Start()
    {
        activeDecorators = new Dictionary<string, BaseAbilityDecorator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ApplyDecorator(string key, BaseAbilityDecorator decorator)
    {
        if (!activeDecorators.ContainsKey(key))
        {
            decorator.Apply(gameObject);
            activeDecorators[key] = decorator;

            // Start timer for speed boost
            if (key == "SpeedBoost")
            {

            }
        }
    }

    private void RemoveDecorator(string key)
    {
        if (activeDecorators.ContainsKey(key))
        {
            activeDecorators[key].Remove(gameObject); // Call the specific decorator's Remove method

            if (key == "SpeedBoost")
            {

            }

            activeDecorators.Remove(key); // Remove from active decorators
        }
    }
}
