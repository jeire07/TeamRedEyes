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
    Health
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string information;
    public string statName;
    public string statValue;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")] //최대보유갯수
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equipable")]
    public EquipableType equipableType; // 추가: 어떤 종류의 장비인지를 나타내는 열거형
}
