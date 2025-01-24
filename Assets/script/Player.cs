using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int health = 100;
    public int defence;

    private void Awake()
    {
        Instance = this;
    }
}
