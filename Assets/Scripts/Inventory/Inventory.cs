using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
public class Inventory : Singleton<Inventory>
{
    public ItemSlot[] slot;
    public ItemSlotUI[] uiSlot;
    public GameObject inventoryPanel;

    public Transform dropPosition;

    [Header("Selected Item")]
    public ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemInformation;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject dropButton;
    public GameObject equipButton;
    public GameObject unEquipButton;

    private int curEquiupIndex;

    //private PlayerController controller;
    private PlayerConditions condition;

    //[Header("Events")]
    //public UnityEvent onOpenInventory;
    //public UnityEvent onCloseInventory;

    
    void Awake()
    {
      condition = GetComponent<PlayerConditions>();
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
        slot = new ItemSlot[uiSlot.Length];

        for(int i = 0; i < slot.Length; i++)
        {
            slot[i] = new ItemSlot();
            uiSlot[i].index = i; 
            uiSlot[i].Clear();
        }

        ClearSelectItemPenal();
    }

    public void OnInventoryButton(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.phase == InputActionPhase.Started)
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        if(inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(false);
            //onCloseInventory?.Invoke();
            //controller.ToggleCusor(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            //onOpenInventory?.Invoke();
            //controller.ToggleCusor(true);
        }
    }

    public bool IsOpen()
    {
        return inventoryPanel.activeInHierarchy;
    }

    public void AddItem(ItemData item)
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if(slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }

            ItemSlot emptySlot = GetEmptySlot();

            if (emptySlot != null)
            {
                emptySlot.item = item;
                emptySlot.quantity = 1;
                UpdateUI();
                return;
            }
        }

        DropItem(item);
    }

    public void DropItem(ItemData item)
    {
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360f)); ;
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item != null)
                uiSlot[i].Set(slot[i]);
            else
                uiSlot[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for(int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item == item && slot[i].quantity < item.maxStackAmount)
                return slot[i];
        }
        
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item == null)
                return slot[i];
        }
        return null;
    }

    public void SelectItem(int index)
    {
        if (slot[index].item == null)
            return;

        selectedItem = slot[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemInformation.text = selectedItem.item.information;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        dropButton.SetActive(true);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlot[index].eqipped);
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlot[index].eqipped);
    }

    private void ClearSelectItemPenal()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemInformation.text = string.Empty;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        dropButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }

    public void OnUseButton()
    {

    }

    public void OnEquipButton()
    {

    }

    public void UnEquip(int index)
    {

    }

    public void OnUnEquipButton()
    {

    }

    public void OnDropButton()
    {
        DropItem(selectedItem.item);
        RemoveSelectedItem();
    }

    private void RemoveSelectedItem()
    {
        selectedItem.quantity--;

        if(selectedItem.quantity <= 0)
        {
            if (uiSlot[selectedItemIndex].eqipped)
            {
                UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
            ClearSelectItemPenal();
        }
        UpdateUI();
    }

    public void RemoveItem(ItemData item)
    {

    }

    public bool HasItem(ItemData item, int quantity)
    {
        return false;
    }
}
