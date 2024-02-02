using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : Singleton<Inventory>
{
    public GameObject InventoryObj;
    public bool IsOpened = false;
    public ItemData ItemData;
    public ItemSlot[] ItemSlot;
    public Transform DropPosition;

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(RestUI.Instance.IsOpened)
        {
            return;
        }

        if (context.phase == InputActionPhase.Started)
        {
            IsOpened = !IsOpened;
            InventoryObj.SetActive(IsOpened);

            if (IsOpened == true)
            {

                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (IsOpened == false)
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public bool AddItem(ItemData item)
    {
        if (item.CanStack)
        {
            ItemSlot slotTostackTo = GetItemStack(item);
            if (slotTostackTo != null)
            {
                slotTostackTo.Quantity++;
                UpdateUI();
                return true;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.Item = item;
            emptySlot.Quantity = 1;
            UpdateUI();
            return true;
        }
        else if(emptySlot == null)
        {
            return false;
        }
        return false;
    }

    public void ThrowItem(ItemData item)
    {
        Instantiate(item.DropPrefab, DropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f));
    }

    void UpdateUI()
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (ItemSlot[i].Item != null)
                ItemSlot[i].Set();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (ItemSlot[i] != null && ItemSlot[i].Item == item && ItemSlot[i].Quantity < item.MaxStackAmount)
                return ItemSlot[i];
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (ItemSlot[i].Item == null)
                return ItemSlot[i]; 
        }
        return null;
    }
}
