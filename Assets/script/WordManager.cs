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

    // Update is called once per frame
    void Update()
    {
        
    }
}
