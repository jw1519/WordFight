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
        if (!panels.Contains(panel))
        {
            panels.Add(panel);
        }
    }
    public BasePanel GetPanel(string name)
    {
        foreach (BasePanel panel in panels)
        {
            if (panel.name == name)
            {
                return panel;
            }
        }
        return null;
    }
}
