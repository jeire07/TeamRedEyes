using UnityEngine;

public class TalkToNPC : MonoBehaviour, IInteractable
{
    //private NPCData _npc;

    public string GetInteractText()
    {
        return "[G] 대화하기 - {_NPC.displayName}";
        //return $"[G] 대화하기 - {_NPC.displayName}";
    }

    public void Interact()
    {
        Debug.Log("대화하기를 시전했다. 코드가 미완성이다");
        //pop up TalkUI for talk or Chat
    }
}
