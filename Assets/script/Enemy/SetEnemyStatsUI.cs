using UnityEngine;
using TMPro;

public class SetEnemyUI : MonoBehaviour
{
    public TextMeshProUGUI defenceText;

    public void UpdateDefence(int defence)
    {
        defenceText.text = defence.ToString();
    }
}
