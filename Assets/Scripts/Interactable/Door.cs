using UnityEngine;
using System.Collections;

// 문 클래스가 상호 작용 가능한 인터페이스를 구현
public class Door : MonoBehaviour, IInteractable
{
    #region private field
    //[SerializeField] private bool _isLocked;
    //[SerializeField] private bool _isOpened;
    //[SerializeField] private float OpenCloseTime;
    #endregion

    #region public field
    public Animator AnimatorDoor;
    public bool _isLocked { get; private set; }
    public bool _isOpened { get; private set; }
    public float OpenCloseTime { get; private set; }

    public Vector3 OpenRotation { get; private set; }
    public Vector3 CloseRotation { get; private set; }
    #endregion

    private void Awake()
    {
        _isLocked = false;
        _isOpened = false;
        OpenCloseTime = 1.0f;
        OpenRotation = new Vector3(0, 90, 0);
        CloseRotation = new Vector3(0, 0, 0);
    }

    public string GetInteractText()
    {
        if (_isLocked)
            return "문이 잠겨있습니다. 열쇠가 있어야합니다.";
        else if (_isOpened)
            return "[G] 문 닫기";
        else
            return "[G] 문 열기";
    }

    public void Interact()
    {
        if (_isOpened)
        {
            Debug.Log($"{AnimatorDoor.name}");
            DoorAnim(AnimatorDoor.name);
        }
        else if (!_isLocked && !_isOpened)
        {
            Debug.Log($"{AnimatorDoor.name}");
            DoorAnim(AnimatorDoor.name);
        }
    }

    private void DoorAnim(string DoorName)
    {
        if (_isOpened == false)
        {
            StartCoroutine(OpenCloseDoor($"Open{DoorName}"));
        }
        else
        {
            StartCoroutine(OpenCloseDoor($"Close{DoorName}"));
        }
    }

    private IEnumerator OpenCloseDoor(string rotate)
    {
        print($"you are {rotate[..3]}ing the door");
        AnimatorDoor.Play(rotate);
        _isOpened = rotate[..8] == "OpenDoor" ? true : false;
        yield return new WaitForSeconds(.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isLocked && !_isOpened && other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            DoorAnim(AnimatorDoor.name);
            _isOpened = true;
        }
    }
}
