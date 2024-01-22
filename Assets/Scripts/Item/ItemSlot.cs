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

    public Button useButton;
    public Button dropButton;
    public Button equipButton;
    public Button unEquipButton;

    public ItemData item;
    public int quantity;


    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        displayName.text = slot.item.displayName;
        information.text = slot.item.information;
        statName.text =  slot.item.statName;
        statValue.text = slot.item.statValue;
        itemIcon.sprite = slot.item.icon;
        quantityText.text = slot.quantity > 1 ? $"X {slot.quantity.ToString()}" : "X 1";

    }

    public void Clear()
    {
        curSlot = null;
        item = null;
        quantityText.text = string.Empty;
    }

}
