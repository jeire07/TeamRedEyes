using UnityEngine;

public enum RestFurniture
{
    Sofa,
    Bed
}

public class Rest : MonoBehaviour, IInteractable
{
    private Transform _restUI;
    private string _furnitureName;

    private void Start()
    {
        _furnitureName = transform.name;

        Transform canvas = GameObject.FindGameObjectWithTag("FrequentUI").GetComponent<Transform>();
        _restUI = canvas.Find("RestUI");
    }

    public string GetInteractText()
    {
        if (_furnitureName == "휴식용 의자")
            return "[G] 의자에서 휴식하기";
        else
            return "[G] 침대에서 한숨자기";
    }

    public void Interact()
    {
        _restUI.GetComponent<RestUI>().OpenUI();

        if (_furnitureName == "휴식용 의자")
            _restUI.GetComponent<RestUI>().SetRestLengthScale((int)RestFurniture.Sofa);
        else
            _restUI.GetComponent<RestUI>().SetRestLengthScale((int)RestFurniture.Bed);
    }
}
