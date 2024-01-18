using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
    public bool IsOpened { get; private set; }
    [SerializeField] private bool _isRotatingDoor = true;
    [SerializeField] private float _speed = 1f;

    [Header("Rotation Configs")]
    [SerializeField] private float _rotationAmount = 90f;
    [SerializeField] private float _forwardDirection = 0;

    private Vector3 _startRotation;
    private Vector3 _forward;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        _forward = transform.right;
    }

    public void Open(Vector3 UserPosition)
    {
        if (AnimationCoroutine != null)
        {
            StopCoroutine(AnimationCoroutine);
        }

        if(_isRotatingDoor)
        {
            float dot = Vector3.Dot(_forward, (UserPosition - transform.position).normalized);
            AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
        }
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(forwardAmount >= _forwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - _rotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + _rotationAmount, 0));
        }

        IsOpened = true;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * _speed;
        }
    }

    public void Close()
    {
        if (AnimationCoroutine != null)
        {
            StopCoroutine(AnimationCoroutine);
        }

        if (_isRotatingDoor)
        {
            AnimationCoroutine = StartCoroutine(DoRotationClose());
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(_startRotation);

        IsOpened = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * _speed;
        }
    }
}
