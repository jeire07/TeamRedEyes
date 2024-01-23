using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;
     
    public string GetInteractText()
    {
        return $"Pickup {item.displayName}";
    }

    public void Interact()
    {
        if(Inventory.Instance.AddItem(item) == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("인벤토리를 비우세요"); // UI로 띄우기
        }
    }
}
