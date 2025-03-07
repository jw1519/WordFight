using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private void Awake()
    {
        ClosePausePanel();
    }
    public void OpenPausePanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePausePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
