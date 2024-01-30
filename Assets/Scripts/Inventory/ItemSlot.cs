using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


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
    private PlayerCondition _Condition;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player"); //Find 사용말고 다른방법 질문, 왜 지양해야 하는지, Find말고 다른방법으로 바꿔보기
        _Condition = player.GetComponent<PlayerCondition>();
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
        QuantityText.text = Quantity > 1 ? $"X {Quantity.ToString()}" : "X 1";
    }

    public void Set()
    {
        SetButton();
        GetItemData();
    }

    public void OnUseButton()
    {
        if (Item.Type == ItemType.Consumable)
        {
            for (int i = 0; i < Item.Consumables.Length; i++)
            {
                switch (Item.Consumables[i].Type)
                {
                    case ConsumableType.Health:
                        _Condition.Potion(Item.Consumables[i].Value); break;
                    case ConsumableType.Hunger:
                        _Condition.Eat(Item.Consumables[i].Value); break;
                    case ConsumableType.Thirsty:
                        _Condition.Drink(Item.Consumables[i].Value); break;
                    case ConsumableType.Infection:
                        _Condition.TakeInfection(Item.Consumables[i].Value); break;
                    case ConsumableType.Immunity:
                        _Condition.TakeImmunity(Item.Consumables[i].Value); break;
                }
            }
            Quantity--;
            QuantityText.text = $"X {Quantity.ToString()}";
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
            Inventory.Instance.ThrowItem(Item);
            Quantity--;
            QuantityText.text = $"X {Quantity.ToString()}";
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
