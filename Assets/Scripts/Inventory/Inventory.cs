using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ItemSlot
{
    //public ItemData item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlot[] slot;
    public ItemSlotUI[] uiSlot;
    public GameObject inventoryPanel;

    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemInfomation;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject dropButton;
    public GameObject equipButton;
    public GameObject unEqipButton;

    private int curEquiupIndex;

    //private PlayerController controller;
    private PlayerConditions condition;

    //[Header("Events")]
    //public UnityEvent onOpenInventory;
    //public UnityEvent onCloseInventory;

    public static Inventory instance;
    void Awake()
    {
      instance = this;
      condition = GetComponent<PlayerConditions>();

    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
        slot = new ItemSlot[uiSlot.Length];

        for(int i = 0; i < slot.Length; i++)
        {
            slot[i] = new ItemSlot();
            //uiSlot[i].index = 
            //uiSlot[i].Clear();
        }

        ClearSelectItemPenal();
    }

    private void ClearSelectItemPenal()
    {

    } 
}
