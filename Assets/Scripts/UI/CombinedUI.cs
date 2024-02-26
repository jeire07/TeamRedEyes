using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombinedUI : MonoBehaviour
{
    private Button[] _buttons;

    void Start()
    {
        Transform buttonParent = transform.Find("Buttons");
        Transform panelParent = transform.Find("Panels");
        
        for (int i = 0; i < buttonParent.childCount; i++)
        {
            Transform childTransform = buttonParent.GetChild(i);
            Button button = childTransform.GetComponent<Button>();

            if (button != null)
            {
                _buttons[i] = button;
                _buttons[i].onClick.AddListener(() => OnButtonClick((PanelType)i));
            }
        }
    }

    public void OnButtonClick(PanelType type)
    {
        UIManager.Instance.ChangePanel(type);
    }
}
