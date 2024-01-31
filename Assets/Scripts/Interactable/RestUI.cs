using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestUI : MonoBehaviour
{
    private Transform _blackBack;
    private Transform _buttonBox;
    private TMP_Text[] _restTimeTexts = new TMP_Text[4];

    private int _restLengthScale;
    private readonly int[] _restTimes = { 1, 2, 4, 3 };

    private void Start()
    {
        _blackBack = transform.GetChild(0);
        _buttonBox = transform.GetChild(1);
    }

    public void OpenUI()
    {
        _blackBack.gameObject.SetActive(true);
        _buttonBox.gameObject.SetActive(true);

        TimeManager.Instance.SetGameSpeed(0);

        SetButtons();
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

    public void CloseUI()
    {
        _blackBack.gameObject.SetActive(true);
        _buttonBox.gameObject.SetActive(true);
    }
}
