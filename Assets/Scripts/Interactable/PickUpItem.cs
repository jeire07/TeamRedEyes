using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private ItemData _item;

    public string GetInteractText()
    {
        return "[G] �ݱ� - {_item.displayName}";
        // ������ �ۼ� ������ �Ʒ� �ڵ�� ���� �ڵ带 ��ü
        // return $"[G] �ݱ� - {_item.displayName}";
    }

    public void Interact()
    {
        //Inventory.Instance.AddItem(_item);
        Debug.Log("������ �ݱ⸦ �����ߴ�. �ڵ尡 �̿ϼ��̴�");
        gameObject.SetActive(false);
    }
}
