using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent { }
public class PlayerAttackEvent : GameEvent
{
    public Enemy Target;
    public int Damage;

    public PlayerAttackEvent(Enemy target, int damage)
    {
        Target = target;
        Damage = damage;
    }
}

