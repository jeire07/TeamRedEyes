using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    private ItemSlot curSlot;

    #region Text    
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI information;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI statName;
    public TextMeshProUGUI statValue;
    #endregion

    #region Button
    public GameObject useButton;
    public GameObject dropButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    #endregion

    public ItemData item;
    public int quantity;

    private void Start()
    {
 
    }

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        displayName.text = slot.item.displayName;
        information.text = slot.item.information;
        statName.text =  slot.item.statName;
        statValue.text = slot.item.statValue;
        itemIcon.sprite = slot.item.icon;
        quantityText.text = slot.quantity > 1 ? $"X {slot.quantity.ToString()}" : "X 1";

        useButton.SetActive(item.type == ItemType.Consumable || item.type == ItemType.Resource);
        equipButton.SetActive(item.type == ItemType.Equipable);
        unEquipButton.SetActive(item.type == ItemType.Equipable);
        dropButton.SetActive(true);
    }

    public void Clear()
    {
        curSlot = null;
        item = null;
        quantityText.text = string.Empty;
    }

    public void OnUseButton()
    {

    }

    public void OnDropButton()
    {

    }

    public void OnEquipButton()
    {

    }

    public void OnUnEquipButton()
    {

    }

    private void UseItem()
    {
        item.type = ItemType.Consumable;
    }

}
