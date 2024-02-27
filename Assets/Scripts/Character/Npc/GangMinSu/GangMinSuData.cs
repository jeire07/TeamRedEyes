using UnityEngine;

public class GangMinSuData : MonoBehaviour
{
   // public PlayerInventory playerInventory;
    public string NpcName = "강민수";
    public string[] Dialogues = new string[]
    {

    };

    public void interact()
    {
        DisplayDialogues();
    }

    private void DisplayDialogues()
    {
        foreach (var dialogue in Dialogues)
        {

        }
    }

    //public void OnRepairButtonClick(Item item)
    //{
    //    if (playerInventory != null)
    //    {
    //        playerInventory.RepairItem(item);
    //    }
    //}

}
