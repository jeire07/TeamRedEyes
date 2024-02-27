using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public Image ItemIcon;
    public GameObject EquipIcon;
    public bool IsEquipped;

    #region Text
    public TextMeshProUGUI DisplayName;
    public TextMeshProUGUI Information;
    public TextMeshProUGUI QuantityText;
    public TextMeshProUGUI StatName;
    public TextMeshProUGUI StatValue;
    #endregion

    #region Button
    public GameObject UseButton;
    public GameObject DropButton;
    public GameObject EquipButton;
    public GameObject UnEquipButton;
    #endregion

    public ItemData Item;
    public int Quantity;

    private Condition[] _conditions;

    private void Awake()
    {
        EquipIcon.SetActive(false);
    }

    private void SetButton()
    {
        DropButton.SetActive(true);

        if (Item.Type == ItemType.Equipable && IsEquipped != true)
        {
            EquipButton.SetActive(true);
        }
        else // Consumable & Resource
        {
            UseButton.SetActive(true);
        }
    }

    private void GetItemData()
    {
        DisplayName.text = Item.DisplayName;
        Information.text = Item.Information;
        StatName.text = Item.StatName;
        StatValue.text = Item.StatValue;
        ItemIcon.sprite = Item.Icon;
        QuantityText.text = Quantity > 1 ? $"X {Quantity}" : "X 1";
    }

    public void Set()
    {
        SetButton();
        GetItemData();
    }

    public void OnUseButton()
    {
        _conditions = PlayerCondition.Instance.Conditions;

        if (Item.Type == ItemType.Consumable)
        {
            for (int i = 0; i < Item.Consumables.Length; i++)
            {
                switch (Item.Consumables[i].Type)
                {
                    case ConsumableType.Health:
                        _conditions[(int)ConditionType.Health].Add(Item.Consumables[i].Value);
                        break;
                    case ConsumableType.Hunger:
                        _conditions[(int)ConditionType.Hunger].Add(Item.Consumables[i].Value);
                        break;
                    case ConsumableType.Thirsty:
                        _conditions[(int)ConditionType.Thirsty].Add(Item.Consumables[i].Value);
                        break;
                    case ConsumableType.Infection:
                        _conditions[(int)ConditionType.Infection].Add(Item.Consumables[i].Value);
                        break;
                    case ConsumableType.Immunity:
                        _conditions[(int)ConditionType.Infection].Add(-1 * Item.Consumables[i].Value);
                        break;
                }
            }

            Quantity--;
            QuantityText.text = $"X {Quantity}";
            if (Quantity <= 0)
            {
                ClearItemSlot();
            }
        }
    }

    public void OnDropButton()
    {
        if (!IsEquipped)
        {
            InventoryManager.Instance.ThrowItem(Item);
            Quantity--;
            QuantityText.text = $"X {Quantity}";
            if (Quantity <= 0)
            {
                ClearItemSlot();
            }
        }
    }

    public void OnEquipButton()
    {
        if(EquipSlot.Instance.Equip(Item))
        IsEquipped = true;
        ChangeEquip();
    }

    public void OnUnEquipButton()
    {
        IsEquipped = false;
        ChangeEquip();
        EquipSlot.Instance.UnEquip(Item);
    }

    private void ChangeEquip()
    {
        if (IsEquipped == false)
        {
            EquipIcon.SetActive(false);
            EquipButton.SetActive(true);
            UnEquipButton.SetActive(false);
        }
        else if (IsEquipped == true)
        {
            EquipIcon.SetActive(true);
            EquipButton.SetActive(false);
            UnEquipButton.SetActive(true);
        }
    }

    private void ClearItemSlot()
    {
        Item = null;
        DisplayName.text = null;
        Information.text = null;
        StatName.text = null;
        StatValue.text = null;
        ItemIcon.sprite = null;
        QuantityText.text = null;

        UseButton.SetActive(false);
        EquipButton.SetActive(false);
        UnEquipButton.SetActive(false);
        DropButton.SetActive(false);
    }
}
