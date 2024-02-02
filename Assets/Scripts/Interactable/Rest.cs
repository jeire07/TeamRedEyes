using UnityEngine;

public enum RestFurniture
{
    Sofa = 1,
    Bed
}

public class Rest : MonoBehaviour, IInteractable
{
    private Transform _restUI;
    private string _furnitureName;

    private void Start()
    {
        Transform canvas = GameObject.FindGameObjectWithTag("NotFrequentUI").GetComponent<Transform>();
        _restUI = canvas.Find("RestUI");

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
            _restUI.GetComponent<RestUI>().SetRestLengthScale((int)RestFurniture.Sofa);
        else
            _restUI.GetComponent<RestUI>().SetRestLengthScale((int)RestFurniture.Bed);

        _restUI.GetComponent<RestUI>().OpenUI();
    }
}
