using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public TextAsset wordsTextAsset;
    [SerializeField] List<string> wordList;
    Trie wordTrie;
    // Start is called before the first frame update
    void Start()
    {
        wordTrie = new Trie();
        string[] line = wordsTextAsset.text.Split("\n");
        wordList = new List<string>(line);

        foreach (string word in wordList)
        {
            if (word.Length <= 7 && word.Length > 1)
            {
                wordTrie.Insert(word.Trim().ToUpper());
            }
        }
    }
    public void SubmitWord()
    {
        string word = "";
        int wordDamage = 0;
        foreach (Transform card in CardManager.instance.useCards)
        {
            string letter = card.GetComponent<SetCard>().card.letter;
            word = word + letter;
            wordDamage = wordDamage + card.GetComponent<SetCard>().card.value;
        }
        if (wordTrie.Search(word))
        {
            foreach (Transform card in CardManager.instance.useCards)
            {
                // get the ICard to play the card
                if (card.GetComponent<SetCard>().card is ICard iCard)
                {
                    iCard.Play();
                }
            }
            CardManager.instance.DiscardUsedCards();
        }
        else
        {
            Debug.Log("This is not a word");
        }
    }
}
