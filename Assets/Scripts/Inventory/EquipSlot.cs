using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public ItemData Item; 
    public Image clothesIcon;
    public Image weaponIcon;
    public Image shoesIcon;


    public void Equip(ItemData itemData)
    {

        Debug.Log($"{itemData.icon}");
        if(itemData.equipableType == EquipableType.Weapon)
        {
            weaponIcon.sprite = itemData.icon;
            Debug.Log($"{weaponIcon.sprite}");
        }
        else if (itemData.equipableType == EquipableType.Shoes)
        {
            shoesIcon.sprite = itemData.icon;
        }
        else if (itemData.equipableType == EquipableType.Clothes)
        {
            clothesIcon.sprite = itemData.icon;
        }
    }

    public void UnEquip()
    {
       
    }
}
