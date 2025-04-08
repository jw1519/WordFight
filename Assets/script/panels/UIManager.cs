using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<BasePanel> panels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        foreach (BasePanel panel in panels)
        {
            RegisterPanel(panel);
        }
    }
    public void RegisterPanel(BasePanel panel)
    {
        if (panels.Contains(panel))
        {
            panel.gameObject.SetActive(true);
        }
    }
}
