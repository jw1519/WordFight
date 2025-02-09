using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public static GameOverPanel instance;

    public int wordsUsed;
    public TextMeshProUGUI wordsUsedText;

    public void Awake()
    {
        instance = this;
    }

    public void SetStats()
    {
        wordsUsedText.text = "Words used:" + wordsUsed;
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
