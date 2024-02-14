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
        //Debug.Log("대화하기를 시전했다. 코드가 미완성이다");
        dialogueUI.SetActive(true);
        foreach (var dialogue in npcSO.dialogues)
        {
            Debug.Log(dialogue); // 실제 구현에서는 대화 UI에 이 내용을 표시해야 합니다.
        }

        if (npcSO.canRepair)
        {
            // 수리 UI 내의 수리 버튼 활성화 로직을 여기에 구현합니다.
            // 예시 코드에서는 단순화를 위해 수리 UI 자체를 활성화합니다.
            repairUI.SetActive(true);
        }
    }

    public void OnRepairButtonClick()
    {
        // 수리 UI 활성화
        repairUI.SetActive(true);
        // 수리 UI에 수리 비용 등의 정보를 표시하는 로직을 여기에 구현합니다.
    }
}
