using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private ItemData _item;

    public string GetInteractText()
    {
        return "[G] 줍기 - {_item.displayName}";
        // 데이터 작성 끝나면 아래 코드로 위의 코드를 대체
        // return $"[G] 줍기 - {_item.displayName}";
    }

    public void Interact()
    {
        //Inventory.Instance.AddItem(_item);
        Debug.Log("아이템 줍기를 시전했다. 코드가 미완성이다");
        gameObject.SetActive(false);
    }
}
