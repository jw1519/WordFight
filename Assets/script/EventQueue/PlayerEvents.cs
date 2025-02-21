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
public class PlayerDefenceEvent : GameEvent
{
    public Player Target;
    public int Defence;

    public PlayerDefenceEvent(Player target, int defence)
    {
        Target = target;
        Defence = defence;
    }
}

