using UnityEngine;

public enum RestFurniture
{
    Sofa = 1,
    Bed
}

public class Rest : MonoBehaviour, IInteractable
{
    private string _furnitureName;

    private void Start()
    {
        _furnitureName = transform.name;
    }

    public string GetInteractText()
    {
        if (_furnitureName != null && _furnitureName == "Sofa")
            return "[G] 의자에서 휴식하기";
        else
            return "[G] 소파에서 한숨자기"; // To Do : 소파를 침대로
    }

    public void Interact()
    {
        UIManager.Instance.ShowCanvas(CanvasType.NotFrequent);
        UIManager.Instance.ShowPanel(PanelType.Rest);

        RestUI restUI = UIManager.Instance.PanelDict[PanelType.Rest].GetComponent<RestUI>();

        if (_furnitureName == "Sofa")
            restUI.SetRestLengthScale((int)RestFurniture.Sofa);
        else
            restUI.SetRestLengthScale((int)RestFurniture.Bed);
    }
}
