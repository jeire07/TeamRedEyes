using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private ItemData _item;

    public string GetInteractText()
    {
        return string.Format("[G] �ݱ� - {_item.displayName}");
    }

    public void Interact()
    {
        //Inventory.Instance.AddItem(_item);
        Debug.Log("������ �ݱ⸦ �����ߴ�. �ڵ尡 �̿ϼ��̴�");
        gameObject.SetActive(false);
    }
}
