using UnityEngine.UI;

public class EquipSlot : Singleton<EquipSlot>
{
    public ItemData Item; 
    public Image clothesIcon;
    public Image weaponIcon;
    public Image shoesIcon;


    public void Equip(ItemData itemData)
    {
        Item = itemData;
 
        if(itemData.equipableType == EquipableType.Weapon)
        {
            weaponIcon.sprite = itemData.icon;
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
