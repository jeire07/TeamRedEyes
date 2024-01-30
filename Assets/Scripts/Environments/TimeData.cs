using UnityEngine;

[CreateAssetMenu(fileName = "Time", menuName = "TimeData")]
public class TimeData : ScriptableObject
{
    public int Day;
    public int Hour;
    public int Minute;
    public int Second;

    public bool IsAM;

    public int MinutesPerDay = 12;
    public int TimeScale = 1;
}
