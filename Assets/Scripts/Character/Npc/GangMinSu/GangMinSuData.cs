using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GangMinSuData : MonoBehaviour
{
   // public PlayerInventory playerInventory;
    public string NpcName = "���μ�";
    public string[] Dialogues = new string[]
    {
        //����Ʈ���� �ۼ�
    };

    public void interact()
    {
        //��ȭUI�ۼ� �߰��ؾߵ�
        DisplayDialogues();
    }

    private void DisplayDialogues()
    {
        //��ȭ���� ǥ��
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
