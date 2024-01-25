using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : Singleton<EquipSlot>
{
    public ItemData Item; 
    public Image clothesIcon;
    public Image weaponIcon;
    public Image shoesIcon;


    public bool Equip(ItemData itemData)
    {
        Item = itemData;
        
        if (itemData.equipableType == EquipableType.Weapon)
        {
            if (weaponIcon.sprite == null)
            {
                weaponIcon.sprite = itemData.icon;
                return true;
            }
        }
        else if (itemData.equipableType == EquipableType.Shoes)
        {
            if (shoesIcon.sprite == null)
            {
                shoesIcon.sprite = itemData.icon;
                return true;
            }
        }
        else if (itemData.equipableType == EquipableType.Clothes)
        {
            if (clothesIcon.sprite == null)
            {   
                clothesIcon.sprite = itemData.icon;
                return true;
            }
        }
        return false;
    }

    public void UnEquip(ItemData itemData)
    {
 
            if (itemData.equipableType == EquipableType.Weapon)
            {
                    weaponIcon.sprite = null;
            }
            else if (itemData.equipableType == EquipableType.Shoes)
            { 
                    shoesIcon.sprite = null;

            }
            else if (itemData.equipableType == EquipableType.Clothes)
            {
                    clothesIcon.sprite = null;
            }
        
    }
}
