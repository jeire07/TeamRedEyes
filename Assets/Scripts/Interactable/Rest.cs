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
            return "[G] 침대에서 한숨자기";
    }

    public void Interact()
    {
        if (_furnitureName == "Sofa")
            RestUI.Instance.SetRestLengthScale((int)RestFurniture.Sofa);
        else
            RestUI.Instance.SetRestLengthScale((int)RestFurniture.Bed);

        RestUI.Instance.GetComponent<RestUI>().OpenUI();
    }
}
