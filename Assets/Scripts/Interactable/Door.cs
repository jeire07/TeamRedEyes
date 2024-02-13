﻿using UnityEngine;
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

    // 상호 작용 인터페이스의 메서드 구현
    public void Interact()
    {
        if (_isOpened)
        {
            DoorAnim();
            //StartCoroutine(RotateDoor(CloseRotation));
        }
        else if (!_isLocked && !_isOpened)
        {
            DoorAnim();
            //StartCoroutine(RotateDoor(OpenRotation));
        }
    }

    private IEnumerator RotateDoor(Vector3 targetRotation)
    {
        float elapsedTime = 0;

        Quaternion startRotation = transform.rotation;
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

        while (elapsedTime < OpenCloseTime)
        {
            transform.parent.rotation = Quaternion.Slerp(startRotation, targetQuaternion, (elapsedTime / OpenCloseTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _isOpened = !_isOpened;
    }

    private void DoorAnim()
    {
        if (_isOpened == false)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        print("you are opening the door");
        AnimatorDoor.Play("OpenDoor");
        _isOpened = true;
        yield return new WaitForSeconds(.5f);
    }

    private IEnumerator CloseDoor()
    {
        print("you are closing the door");
        AnimatorDoor.Play("CloseDoor");
        _isOpened = false;
        yield return new WaitForSeconds(.5f);
    }

    // 몬스터는 문 앞뒤로 트리거 충돌 영역을 설정하여 자동으로 열리도록 처리함
    private void OnTriggerEnter(Collider other)
    {
        if (!_isLocked && !_isOpened && other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            DoorAnim();
            _isOpened = true;
        }
    }
}
