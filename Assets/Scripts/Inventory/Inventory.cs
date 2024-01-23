using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    
    public GameObject inventory;
    public bool IsOpened = false;
    public ItemData item;
    public ItemSlot[] itemSlot;

    private void Awake()
    {
        //itemSlot = new ItemSlot[10];
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(IsOpened == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(IsOpened == false)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OnInventory()
    {
        IsOpened = !IsOpened;
        inventory.SetActive(IsOpened);
    }


    public bool AddItem(ItemData item)
    {
        if(item.canStack)
        {
            ItemSlot slotTostackTo = GetItemStack(item);
            if(slotTostackTo != null)
            {
                slotTostackTo.quantity++;
                UpdateUI();
                return true;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return true;
        }
        else if (emptySlot == null)
        {
            return false;
        }
        return false;
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].item != null)
                itemSlot[i].Set(itemSlot[i]);
            else
                itemSlot[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i] != null && itemSlot[i].item == item && itemSlot[i].quantity < item.maxStackAmount)
                return itemSlot[i];
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].item == null)
                return itemSlot[i];
        }

        return null;
    }
}
