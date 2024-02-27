using TMPro;
using UnityEngine;

public class RestUI : MonoBehaviour
{
    private Transform[] _UIObjects;
    private TMP_Text[] _restTimeTexts = new TMP_Text[4];
    private int[] _restTimes = { 1, 2, 4, 3 };
    private int _restLengthScale;

    private void Start()
    {
        _restLengthScale = 1;

        _UIObjects = new Transform[transform.childCount];
        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i] = transform.GetChild(i);
        }

        for (int i = 0; i < _restTimes.Length; i++)
        {
            _restTimeTexts[i] = _UIObjects[1].GetChild(i).GetChild(0).GetComponent<TMP_Text>();
        }
    }

    public void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;

        SetButtons();

        TimeManager.Instance.SetGameSpeed(0f);

        for(int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        TimeManager.Instance.SetGameSpeed(1f);
    }

    private void SetButtons()
    {
        //for (int i = 0; i < _restTimes.Length; i++)
        //{
        //    _restTimeTexts[i].text = $"{_restTimes[i] * _restLengthScale}h";
        //}
    }

    public void SetRestLengthScale(int scale)
    {
        _restLengthScale = scale;
    }

    public void OnCancelClick()
    {
        this.gameObject.SetActive(false);
    }

    public void OnStartClick()
    {
        for (int i = 1; i < _UIObjects.Length; i++)
        {
            _UIObjects[i].gameObject.SetActive(false);
        }

        RestHandler.Instance.RestStart();
    }
}
