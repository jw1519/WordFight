using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public void OpenPausePanel()
    {
        gameObject.SetActive(true);
    }
    public void ClosePausePanel()
    {
        gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
