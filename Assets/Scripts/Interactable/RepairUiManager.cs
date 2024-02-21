using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class RepairUIManager : MonoBehaviour
{
    public GameObject slotPrefab; // 슬롯 프리팹
    public Transform contentTransform; // ScrollView의 Content Transform
    public List<ItemData> itemsToRepair; // 수리가 필요한 아이템 목록
    //public PlayerInventory playerInventory;

    //void Start()
    //{
    //    GenerateRepairSlots();
    //}

    //void GenerateRepairSlots()
    //{
    //    foreach (var itemData in playerInventory.itemsToRepair) // 가정: PlayerInventory에서 수리가 필요한 아이템 목록을 관리
    //    {
    //        if (itemData.Type == ItemType.Equipable && itemData.NeedsRepair)
    //        {
    //            GameObject slot = Instantiate(slotPrefab, contentTransform);
    //            var slotImage = slot.GetComponentInChildren<Image>();
    //            var repairButton = slot.GetComponentInChildren<Button>();

    //            slotImage.sprite = itemData.Icon; // 아이템 아이콘 설정
    //            repairButton.onClick.AddListener(() => playerInventory.RepairItem(itemData)); // 수리 버튼 클릭 이벤트 연결
    //        }
    //    }
    //}

    // 아이템 수리 메서드
    public void RepairItem(ItemData item)
    {
        // 수리 로직 구현
        item.CurrentDurability = item.MaxDurability; // 아이템 내구도 복구
        item.NeedsRepair = false; // 수리 필요 상태 해제
        Debug.Log($"{item.DisplayName} 수리됨");
    }
}
