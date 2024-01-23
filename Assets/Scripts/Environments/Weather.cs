using UnityEngine;

public enum WeatherType
{
    Sunny,
    Rainy,
    Snowy,
    Windy
}

public class WeatherManager : Singleton<WeatherManager>
{
    public WeatherType CurWeather { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CurWeather = WeatherType.Sunny;
    }

    private WeatherType SetRandomWeather()
    {
        return (WeatherType)Random.Range(0, 4);
    }

    public void OnDayChange()
    {
        SetRandomWeather();
    }
}
