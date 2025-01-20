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
        int wordDamage = 0;
        foreach (Transform card in GameManager.instance.useCards)
        {
            string letter = card.GetComponent<SetCard>().card.letter;
            word = word + letter;
            wordDamage = wordDamage + card.GetComponent<SetCard>().card.damage;
        }
        Debug.Log(word);

        //check if it is a word

        //if is a word
        //enemy health = health - wordDamage
        foreach (Transform card in GameManager.instance.useCards)
        {
            card.GetComponent<SetCard>();
            GameManager.instance.
        }
    }
    public void EndTurn()
    {
        GameManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }
}
