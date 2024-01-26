using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractText()
    {
        return $"Pickup {item.DisplayName}";
    }

    public void Interact()
    {
        if(Inventory.Instance.AddItem(item))
        {
            //gameObject.SetActive(false); 오브젝트풀로 교체하기
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("인벤토리를 비우세요"); // UI로 띄우기
        }
    }
}
