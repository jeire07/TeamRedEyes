using System.Collections.Generic;
using UnityEngine;

public class RepairUIManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform contentTransform; // ScrollView Content Transform
    public List<ItemData> itemsToRepair;
    //public PlayerInventory playerInventory;

    //void Start()
    //{
    //    GenerateRepairSlots();
    //}

    //void GenerateRepairSlots()
    //{
    //    foreach (var itemData in playerInventory.itemsToRepair)
    //    {
    //        if (itemData.Type == ItemType.Equipable && itemData.NeedsRepair)
    //        {
    //            GameObject slot = Instantiate(slotPrefab, contentTransform);
    //            var slotImage = slot.GetComponentInChildren<Image>();
    //            var repairButton = slot.GetComponentInChildren<Button>();

    //            slotImage.sprite = itemData.Icon; 
    //            repairButton.onClick.AddListener(() => playerInventory.RepairItem(itemData)); 
    //        }
    //    }
    //}


    public void RepairItem(ItemData item)
    {

        item.CurrentDurability = item.MaxDurability;
        item.NeedsRepair = false; 
    }
}
