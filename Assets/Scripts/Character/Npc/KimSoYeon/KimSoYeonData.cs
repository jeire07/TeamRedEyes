using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimSoYeonData : MonoBehaviour
{
    public string NpcName = "��ҿ�";
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
