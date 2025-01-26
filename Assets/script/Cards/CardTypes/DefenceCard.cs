using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Defence Card")]
public class DefenceCard : Card
{
    public int defence;
    public override void Use()
    {
        Player player = FindFirstObjectByType<Player>();
        if (player != null )
        {
            player.defence = player.defence + defence; // change to decorator later
        }
    }
}
