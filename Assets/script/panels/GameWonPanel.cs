using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonPanel : MonoBehaviour
{

    public void Awake()
    {
        gameObject.SetActive(false);
    }
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
