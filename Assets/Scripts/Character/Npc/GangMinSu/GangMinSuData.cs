using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GangMinSuData : MonoBehaviour
{
   // public PlayerInventory playerInventory;
    public string NpcName = "강민수";
    public string[] Dialogues = new string[]
    {
        //퀘스트내용 작성
    };

    public void interact()
    {
        //대화UI작성 추가해야됨
        DisplayDialogues();
    }

    private void DisplayDialogues()
    {
        //대화내용 표기
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
