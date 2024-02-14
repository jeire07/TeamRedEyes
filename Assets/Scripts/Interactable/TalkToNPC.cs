using System.Xml.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class TalkToNPC : MonoBehaviour, IInteractable
{
    public NpcSO npcSO;
    public GameObject dialogueUI;
    public GameObject repairUI;

    void Start()
    {
        dialogueUI.SetActive(false);
        repairUI.SetActive(false);
    }
    public string GetInteractText()
    {
        return $"[G] 대화하기 - {npcSO.npcName}";
    }

    public void Interact()
    {
        DisplayDialogues(npcSO.dialogues);
    }

    private void DisplayDialogues(string[] dialogues)
    {
        // 대화 내용을 표시하는 UI 로직을 여기에 구현합니다.
        Debug.Log($"대화 시작: {npcSO.npcName}");
        foreach (var dialogue in dialogues)
        {
            Debug.Log(dialogue); // 실제 구현에서는 대화 UI에 이 내용을 표시해야 합니다.
        }
        // 대화 UI 활성화 및 대화 내용 업데이트 로직 구현 필요
    }

    public void OnRepairButtonClick()
    {
        // 수리 UI 활성화
        repairUI.SetActive(true);
        // 수리 UI에 수리 비용 등의 정보를 표시하는 로직을 여기에 구현합니다.
    }
}
