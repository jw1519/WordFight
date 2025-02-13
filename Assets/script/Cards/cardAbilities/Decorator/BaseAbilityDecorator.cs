using UnityEngine;

public abstract class BaseAbilityDecorator : MonoBehaviour
{
    protected GameObject player;

    // Constructor for initialising the player object
    public BaseAbilityDecorator(GameObject player)
    {
        this.player = player;
    }
    // Default apply and remove functionality with logging
    public virtual void Apply(GameObject gameObject)
    {
        Debug.Log($"{GetType().Name} applied to {player.name}");
    }
    public virtual void Remove(GameObject gameObject)
    {
        Debug.Log($"{GetType().Name} removed from {player.name}");
    }
}
