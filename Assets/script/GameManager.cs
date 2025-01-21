using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxCards = 7;

    [Header("Buttons")]
    public Button submitButton;
    public Button endTurnButton;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        BeginTurn();
    }

    public void BeginTurn()
    {
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }
    public void EndTurn()
    {
        CardManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }
}
