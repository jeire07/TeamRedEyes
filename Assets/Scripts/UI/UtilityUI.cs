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

public class UtilityUI : MonoBehaviour
{
    private Button[] _buttons;

    void Start()
    {
        Transform buttonParent = transform.Find("Buttons");
        
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
    }
    
    void Update()
    {
        
    }

    private void OnButtonClick(UtilButton buttonType)
    {
        
    }
}
