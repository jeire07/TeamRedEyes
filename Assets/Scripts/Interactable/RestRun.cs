using TMPro;
using UnityEngine;

public class RestSelectButton : MonoBehaviour
{
    [SerializeField] private TimeData _timeData;
    private int _hour;
    private int _minute;

    private int _timeScale;
    private int _restTimeLength;
    private TMP_Text _restTime;

    private void Start()
    {
        _hour = _timeData.Hour;
        _minute = _timeData.Minute;

        _restTime = transform.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        int.TryParse(_restTime.text.Substring(0, _restTime.text.Length - 1), out _restTimeLength);
    }

    private bool CheckTime()
    {
        //if()
        //{
        //    RestEnd();
        //}
        return true;
    }

    private void RestStart()
    {
        TimeManager.Instance.SetGameSpeed(_timeScale);
    }

    private void RestEnd()
    {
        TimeManager.Instance.SetGameSpeed(1);

        transform.parent.GetComponent<RestUI>().CloseUI();
    }
}
