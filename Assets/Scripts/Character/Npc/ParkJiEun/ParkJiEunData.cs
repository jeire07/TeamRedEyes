using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkJiEunData : MonoBehaviour
{
    public string NpcName = "������";
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
}
