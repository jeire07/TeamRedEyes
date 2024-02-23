using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueSystem: MonoBehaviour
{
    public TMP_Text dialogueText;
    public QuestData[] questData;
    public GameObject CanvasDialogues;
    
    private int currentQuestIndex = 0;
    private int currentDialogueIndex = 0;


    private void OnEnable()
    {
        UpdateQuestDialogue();
    }

    public void UpdateQuestProgress()
    {
        currentQuestIndex++;   
    }

    public void EnableDialogues()
    { 
        CanvasDialogues.SetActive(true);    
    }
    public void UpdateQuestDialogue()
    {
        string[] currentQuestDialogues = GetQuestDialogues(currentQuestIndex);

        if (currentDialogueIndex < currentQuestDialogues.Length)
        {
            dialogueText.text = currentQuestDialogues[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            dialogueText.text = "";
            currentDialogueIndex = 0;        
            CanvasDialogues.SetActive(false);
        }
    }

    private string[] GetQuestDialogues(int questIndex)
    {
        return questData[questIndex].Dialogues;
    }
}




