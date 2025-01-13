using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button submitButton;
    public Button endTurnButton;
    public void SubmitWord()
    {
        string word = "";
        foreach (Transform card in GameManager.instance.useCards)
        {
            string letter = card.GetComponent<SetCard>().card.letter;
            word = word + letter;
        }
        Debug.Log(word);
    }
    public void EndTurn()
    {
        GameManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }
}
