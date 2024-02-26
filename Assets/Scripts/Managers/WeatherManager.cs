using UnityEngine;

public enum WeatherType
{
    Sunny,
    Rainy,
    //Snowy,
    Windy
}

public class WeatherManager : Singleton<WeatherManager>
{
    private WeatherType _curWeather;

    // Start is called before the first frame update
    void Start()
    {
        //default weather
        _curWeather = WeatherType.Sunny;
    }

    public WeatherType GetTodayWeather()
    {
        return _curWeather;
    }

    private void SetRandomWeather()
    {
        _curWeather = (WeatherType)Random.Range(0, 4);
    }

    public void OnDayChange()
    {
        SetRandomWeather();
    }
}


public interface IWeatherState
{
    void ApplyEffects(WeatherBuffDebuff player);
}

// 구체적인 날씨 상태 클래스들
public class SunnyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // 맑음에 따른 효과 적용
        player.ApplyClearWeatherEffects();
    }
}

public class RainyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // 비에 따른 효과 적용
        player.ApplyRainyWeatherEffects();
    }
}

public class WindyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // 강풍에 따른 효과 적용
        player.ApplyWindyWeatherEffects();
    }
}

// 플레이어 클래스
public class WeatherBuffDebuff
{
    private IWeatherState weatherState;

    public void SetWeatherState(IWeatherState state)
    {
        weatherState = state;
    }

    public void ApplyWeatherEffects()
    {
        weatherState.ApplyEffects(this);
    }

    // 다양한 날씨에 따른 효과 메서드들...
    public void ApplyClearWeatherEffects() { /* ... */ }
    public void ApplyRainyWeatherEffects() { /* ... */ }
    public void ApplyWindyWeatherEffects() { /* ... */ }
}