using UnityEngine;

public class RestHandler : MonoBehaviour
{
    private TimeData _timeData;

    private bool _isResting;
    private float _restingTime;

    private int _hour;
    private int _minute;

    private int _timeScale;

    // Start is called before the first frame update
    void Start()
    {
        _timeData = Resources.Load<TimeData>("Utility/Time");

        _hour = _timeData.Hour;
        _minute = _timeData.Minute;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isResting)
        {
            _restingTime -= Time.deltaTime;

            if (_restingTime <= 0)
            {
                RestEnd();
            }
        }
    }

    public void RestStart()
    {
        TimeManager.Instance.SetGameSpeed(_timeScale);

        if (_timeData.RestHours > 0 && !_isResting)
        {
            _isResting = true;
            TimeManager.Instance.SetGameSpeed(_timeScale);

            _restingTime = _timeData.RestHours * _timeData.MinutesPerDay * 60 / _timeData.TimeScale;
        }
    }

    private void RestEnd()
    {
        _isResting = false;
        TimeManager.Instance.SetGameSpeed(0);

        transform.parent.GetComponent<RestUI>().CloseUI();
    }
}
