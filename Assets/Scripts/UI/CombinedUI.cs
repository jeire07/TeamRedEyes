using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UtilButton
{
    Stat,
    Item,
    Equip,
    Quest,
    Option,
    Save
}

public class CombinedUI : MonoBehaviour
{
    private Button[] _buttons;
    private GameObject[] _panels;
    private GameObject _currentPanel;

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
                _buttons[i].onClick.AddListener(() => OnButtonClick((UtilButton)i));
            }
        }

        for (int i = 0; i < buttonParent.childCount; i++)
        {
            Transform childTransform = buttonParent.GetChild(i);
            GameObject panel = childTransform.GetComponent<GameObject>();

            if (panel != null)
            {
                _panels[i] = panel;
            }
        }
    }

    //public void OnButtonClick(int buttonType)
    public void OnButtonClick(UtilButton type)
    {


        _currentPanel.SetActive(false);

    }
}
