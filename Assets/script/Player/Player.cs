using UnityEngine;

public class Player : BasePlayer
{
    public void Awake()
    {
        playerUI = GetComponent<SetPlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdatePlayerHealth(this);
        }
    }
}
