using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractText()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void Interact()
    {
        Inventory.Instance.AddItem(item);
        gameObject.SetActive(false);
    }
}
