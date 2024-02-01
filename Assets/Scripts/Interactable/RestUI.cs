using UnityEngine;
using TMPro;

public class RestUI : MonoBehaviour
{
    private Transform[] _UIObjects;
    private TMP_Text[] _restTimeTexts = new TMP_Text[4];
    private readonly int[] _restTimes = { 1, 2, 4, 3 };
    private int _restLengthScale;

    private void Start()
    {
        _UIObjects = new Transform[transform.childCount];

        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i] = transform.GetChild(i);
        }
    }

    public void OpenUI()
    {
        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i].gameObject.SetActive(true);
        }

        SetButtons();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        TimeManager.Instance.SetGameSpeed(0);
        Time.timeScale = 0;
    }

    public void CloseUI()
    {
        for (int i = 0; i < _UIObjects.Length; i++)
        {
            _UIObjects[i].gameObject.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        TimeManager.Instance.SetGameSpeed(1);
        Time.timeScale = 1;
    }

    private void SetButtons()
    {
        for (int i = 0; i < _restTimes.Length; i++)
        {
            _restTimeTexts[i] = transform.GetChild(1).GetChild(i).GetComponentInChildren<TMP_Text>();

            _restTimeTexts[i].text =$"{_restTimes[i] * _restLengthScale}h";
        }
    }

    public void SetRestLengthScale(int scale)
    {
        _restLengthScale = scale;
    }
}
