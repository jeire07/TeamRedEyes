using UnityEngine;

public enum ItemType
{
    Resource,
    Consumable,
    Equipable
}

public enum EquipableType
{
    Shoes,
    Clothes,
    Weapon,
    Shield
}

public enum ConsumableType
{
    Thirsty,
    Hunger,
    Health,
    Infection,
    Immunity
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType Type;
    public float Value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string DisplayName;
    public string Information;
    public string StatName;
    public string StatValue;
    public ItemType Type;
    public Sprite Icon;
    public GameObject DropPrefab;
    public bool IsCorrupted; //상한지 확인

    [Header("Stacking")] //최대보유갯수
    public bool CanStack;
    public int MaxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] Consumables;

    [Header("Equipable")]
    public EquipableType EquipableType; // 추가: 어떤 종류의 장비인지를 나타내는 열거형
}
