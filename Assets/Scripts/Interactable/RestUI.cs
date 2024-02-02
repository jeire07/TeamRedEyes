using TMPro;
using UnityEngine;

public class RestUI : Singleton<RestUI>
{
    public bool IsOpened;

    private Transform[] _UIObjects;
    private TMP_Text[] _restTimeTexts = new TMP_Text[4];
    private int[] _restTimes = { 1, 2, 4, 3 };
    private int _restLengthScale;

    private void Start()
    {
        IsOpened = false;
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

    public void OpenUI()
    {
        IsOpened = true;

        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i].gameObject.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;

        SetButtons();

        TimeManager.Instance.SetGameSpeed(0f);
    }

    public void CloseUI()
    {
        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i].gameObject.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;

        TimeManager.Instance.SetGameSpeed(1f);

        IsOpened = false;
    }

    private void SetButtons()
    {
        for (int i = 0; i < _restTimes.Length; i++)
        {
            _restTimeTexts[i].text = $"{_restTimes[i] * _restLengthScale}h";
        }
    }

    public void SetRestLengthScale(int scale)
    {
        _restLengthScale = scale;
    }

    public void OnCancelClick()
    {
        CloseUI();
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
