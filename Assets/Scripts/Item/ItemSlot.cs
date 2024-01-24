using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public GameObject equipIcon;

    #region Text    
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI information;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI statName;
    public TextMeshProUGUI statValue;
    #endregion

    #region Button
    public GameObject useButton;
    public GameObject dropButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    #endregion

    public ItemData item;
    public int quantity;
    private PlayerConditions condition;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player"); //Find 사용말고 다른방법 질문, 왜 지양해야 하는지, Find말고 다른방법으로 바꿔보기
        condition = player.GetComponent<PlayerConditions>();
    }

    private void Update()
    {
        if (item == null)
        {
            useButton.SetActive(false);
            equipButton.SetActive(false);
            unEquipButton.SetActive(false);
            dropButton.SetActive(false);
            equipIcon.SetActive(false);
        }
    }

    public void Set()
    {
        displayName.text = item.displayName;
        information.text = item.information;
        statName.text = item.statName;
        statValue.text = item.statValue;
        itemIcon.sprite = item.icon;
        quantityText.text = quantity > 1 ? $"X {quantity.ToString()}" : "X 1";

        useButton.SetActive(item.type == ItemType.Consumable);
        dropButton.SetActive(true);

        if (item.type == ItemType.Equipable)
        {
            equipButton.SetActive(true);
            unEquipButton.SetActive(false);
            equipIcon.SetActive(false);
        }
    }

    public void Clear()
    {
        item = null;
    }


    public void OnUseButton()
    {
        if (item.type == ItemType.Consumable)
        {
            for (int i = 0; i < item.consumables.Length; i++)
            {
                switch (item.consumables[i].type)
                {
                    case ConsumableType.Health:
                        condition.Heal(item.consumables[i].value); break;
                    case ConsumableType.Hunger:
                        condition.Eat(item.consumables[i].value); break;
                    case ConsumableType.Thirsty:
                        condition.Drink(item.consumables[i].value); break;
                }
            }
            quantity--;
            quantityText.text = $"X {quantity.ToString()}";
            if (quantity <= 0)
            {
                ClearItemSlot();
            }
        }
    }

    public void OnDropButton()
    {
        if (!item.isEquipped)
        {
            Inventory.Instance.ThrowItem(item);
            quantity--;
            quantityText.text = $"X {quantity.ToString()}";
            if (quantity <= 0)
            {
                ClearItemSlot();
            }
        }
    }

    public void OnEquipButton()
    {
        item.isEquipped = true;
        ChangeEquip();
        EquipSlot.Instance.Equip(item);
    }

    public void OnUnEquipButton()
    {
        item.isEquipped = false;
        ChangeEquip();
        EquipSlot.Instance.UnEquip(item);
    }

    private void ChangeEquip()
    {
        if (item.isEquipped == false)
        {
            equipIcon.SetActive(false);
            equipButton.SetActive(true);
            unEquipButton.SetActive(false);
        }
        else if (item.isEquipped == true)
        {
            equipIcon.SetActive(true);
            equipButton.SetActive(false);
            unEquipButton.SetActive(true);
        }
    }

    private void ClearItemSlot()
    {
        Clear();
        displayName.text = null;
        information.text = null;
        statName.text = null;
        statValue.text = null;
        itemIcon.sprite = null;
        quantityText.text = null;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }
}
