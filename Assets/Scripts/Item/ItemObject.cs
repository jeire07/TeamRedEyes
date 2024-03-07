using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractText()
    {
        return $"[G] {item.DisplayName} 줍기";
    }

    public void Interact()
    {
        if(InventoryManager.Instance.AddItem(item))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("인벤토리를 비우세요"); // UI로 띄우기
        }
    }
}
