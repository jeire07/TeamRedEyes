using UnityEngine;
using UnityEngine.UI;

public class TalkToNPC : MonoBehaviour, IInteractable
{
    //private NPCData _npc;

    public string GetInteractText()
    {
        return string.Format("[G] ��ȭ�ϱ� - {_NPC.displayName}");
        //return string.Format($"[G] ��ȭ�ϱ� - {_NPC.displayName}");
    }

    public void Interact()
    {
        Debug.Log("��ȭ�ϱ⸦ �����ߴ�. �ڵ尡 �̿ϼ��̴�");
        //pop up TalkUI for talk or Chat
    }
}
