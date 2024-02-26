using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    public GameObject Help;
    public bool IsOpened = false;
    public GameObject Enemy;
    public GameObject NthDoorBlock;
    public GameObject DoorBlock;
    public GameObject NPC;

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
    }

    public void OnF1Key(InputAction.CallbackContext context) // 나중에 옮기기
    {
        if (context.phase == InputActionPhase.Started)
        {
            IsOpened = !IsOpened;
            Help.SetActive(IsOpened);
        }
    }
}
