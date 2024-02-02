using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : Singleton<EquipSlot>
{
    public ItemData Item; 
    public Image ClothesIcon;
    public Image WeaponIcon;
    public Image ShoesIcon;

    public bool Equip(ItemData itemData)
    {
        Item = itemData;
        
        if (itemData.EquipableType == EquipableType.Weapon)
        {
            if (WeaponIcon.sprite == null)
            {
                WeaponIcon.sprite = itemData.Icon;
                return true;
            }
        }
        else if (itemData.EquipableType == EquipableType.Shoes)
        {
            if (ShoesIcon.sprite == null)
            {
                ShoesIcon.sprite = itemData.Icon;
                return true;
            }
        }
        else if (itemData.EquipableType == EquipableType.Clothes)
        {
            if (ClothesIcon.sprite == null)
            {   
                ClothesIcon.sprite = itemData.Icon;
                return true;
            }
        }
        return false;
    }

    public void UnEquip(ItemData itemData)
    {
        if (itemData.EquipableType == EquipableType.Weapon)
        {
            WeaponIcon.sprite = null;
        }
        else if (itemData.EquipableType == EquipableType.Shoes)
        {
            ShoesIcon.sprite = null;
        }
        else if (itemData.EquipableType == EquipableType.Clothes)
        {
            ClothesIcon.sprite = null;
        }
    }
}
