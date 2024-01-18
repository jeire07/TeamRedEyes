using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,
    Consumable,
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

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string information;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")] //최대보유갯수
    public bool canStack;
    public int maxStackAmount;

}