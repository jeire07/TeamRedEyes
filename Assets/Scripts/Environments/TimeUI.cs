using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _AMPMText;
    [SerializeField] private bool _is24HourFormat = false;

    private void Awake()
    {
        _timeText = transform.GetChild(1).GetComponent<TMP_Text>();
        _AMPMText = transform.GetChild(1).GetComponent<TMP_Text>();

        TimeManager.Instance.OnMinutePassed += UpdateTimeUI;
    }

    //private void OnDisable()
    //{
    //    TimeManager.Instance.OnMinutePassed -= UpdateTimeUI;
    //}

    private void UpdateTimeUI()
    {
        if (TimeManager.Instance != null)
        {
            string[] TimeData = TimeManager.Instance.GetFormattedTime(_is24HourFormat);

            _timeText.text = TimeData[1];
        }
    }
}
