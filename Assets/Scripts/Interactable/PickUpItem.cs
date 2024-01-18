using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private ItemData _item;

    public string GetInteractText()
    {
        return string.Format("[G] 줍기 - {_item.displayName}");
    }

    public void Interact()
    {
        //Inventory.Instance.AddItem(_item);
        Debug.Log("아이템 줍기를 시전했다. 코드가 미완성이다");
        gameObject.SetActive(false);
    }
}
