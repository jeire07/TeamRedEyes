using System.ComponentModel;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    
    public GameObject inventory;
    private bool _isOpened = false;
    public ItemData item;
    public ItemSlot[] itemSlot;

    private void Awake()
    {
        itemSlot = new ItemSlot[10];
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(_isOpened == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(_isOpened == false)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OnInventory()
    {
        _isOpened = !_isOpened;
        inventory.SetActive(_isOpened);
    }


    public void AddItem(ItemData item)
    {
       if(itemSlot == null)
       {
            
       }
    }
}
