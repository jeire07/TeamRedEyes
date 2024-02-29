using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    public bool IsOpened = false;
    public GameObject Enemy;
    public GameObject NthDoorBlock;
    public GameObject DoorBlock;
    public GameObject NPC;
    public GameObject CanvasDialogues;
    public GameObject TutorialQuest1;
    public TMP_Text TutorialQuest1Text;
    public GameObject TutorialQuest2;

    private void Start()
    {
        Enemy = GameObject.FindWithTag("Enemy");
    }
    private void Update()
    {
        if(Enemy == null)
        {
            NthDoorBlock.SetActive(false);
        }
        if (!CanvasDialogues.activeSelf)
        {
            NPC.SetActive(false);
        }
        if (!NPC.activeSelf)
        {
            DoorBlock.SetActive(false);
            CountMonsterAndCompleteQuest();
        }
    }


    private void CountMonsterAndCompleteQuest()
    {
        int countMonster = CountMonstersWithTag("Enemy");
        TutorialQuest1Text.text = $"6층 몬스터 처치 {5-countMonster} / 5";
        if (countMonster <= 0)
        {
            TutorialQuest1.SetActive(false);
            TutorialQuest2.SetActive(true);
        }
    }

    private int CountMonstersWithTag(string tag)
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(tag);
        return monsters.Length;
    }
}
