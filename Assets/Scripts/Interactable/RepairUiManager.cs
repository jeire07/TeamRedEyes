using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class RepairUIManager : MonoBehaviour
{
    public GameObject slotPrefab; // ���� ������
    public Transform contentTransform; // ScrollView�� Content Transform
    public List<ItemData> itemsToRepair; // ������ �ʿ��� ������ ���
    //public PlayerInventory playerInventory;

    //void Start()
    //{
    //    GenerateRepairSlots();
    //}

    //void GenerateRepairSlots()
    //{
    //    foreach (var itemData in playerInventory.itemsToRepair) // ����: PlayerInventory���� ������ �ʿ��� ������ ����� ����
    //    {
    //        if (itemData.Type == ItemType.Equipable && itemData.NeedsRepair)
    //        {
    //            GameObject slot = Instantiate(slotPrefab, contentTransform);
    //            var slotImage = slot.GetComponentInChildren<Image>();
    //            var repairButton = slot.GetComponentInChildren<Button>();

    //            slotImage.sprite = itemData.Icon; // ������ ������ ����
    //            repairButton.onClick.AddListener(() => playerInventory.RepairItem(itemData)); // ���� ��ư Ŭ�� �̺�Ʈ ����
    //        }
    //    }
    //}

    // ������ ���� �޼���
    public void RepairItem(ItemData item)
    {
        // ���� ���� ����
        item.CurrentDurability = item.MaxDurability; // ������ ������ ����
        item.NeedsRepair = false; // ���� �ʿ� ���� ����
        Debug.Log($"{item.DisplayName} ������");
    }
}
