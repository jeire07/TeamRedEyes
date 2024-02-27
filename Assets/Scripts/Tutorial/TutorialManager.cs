using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    public bool IsOpened = false;
    public GameObject Enemy;
    public GameObject NthDoorBlock;
    public GameObject DoorBlock;
    public GameObject NPC;
    public GameObject CanvasDialogues;

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
        if(!NPC.activeSelf)
        {
            DoorBlock.SetActive(false);
        }
        if (!CanvasDialogues.activeSelf)
        {
            NPC.SetActive(false);
        }
    }
}
