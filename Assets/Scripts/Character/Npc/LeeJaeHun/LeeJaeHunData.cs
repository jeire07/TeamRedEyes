using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeJaeHunData : MonoBehaviour
{
    public string NpcName = "이재훈";
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
}
