using TMPro;
using UnityEngine;

public class RestTimeSelect : MonoBehaviour
{
    private TimeData _timeData;

    private TMP_Text _restTimeText;

    private void Start()
    {
        _timeData = Resources.Load<TimeData>("Utility/Time");
        _restTimeText = transform.GetComponentInChildren<TMP_Text>();
    }

    public void OnClick()
    {
        int.TryParse(_restTimeText.text.Substring(0, _restTimeText.text.Length - 1), out _timeData.RestHours);
    }
}
