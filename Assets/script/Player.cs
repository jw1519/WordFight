using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int health = 100;

    private void Awake()
    {
        Instance = this;
    }
    public void Attack()
    {

    }
}
