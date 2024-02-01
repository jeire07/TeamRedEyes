using UnityEngine;

[CreateAssetMenu(fileName = "Time", menuName = "TimeData")]
public class TimeData : ScriptableObject
{
    public int MinutesPerDay = 12;
    public int TimeScale = 1;

    public int Day = 0;
    public bool IsAM = false;
    public int Hour = 12;
    public int Minute = 0;
    public int Second = 0;

    public int RestHours = 0;
}
