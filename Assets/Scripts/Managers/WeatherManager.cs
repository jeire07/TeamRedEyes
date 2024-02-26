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

// ��ü���� ���� ���� Ŭ������
public class SunnyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // ������ ���� ȿ�� ����
        player.ApplyClearWeatherEffects();
    }
}

public class RainyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // �� ���� ȿ�� ����
        player.ApplyRainyWeatherEffects();
    }
}

public class WindyState : IWeatherState
{
    public void ApplyEffects(WeatherBuffDebuff player)
    {
        // ��ǳ�� ���� ȿ�� ����
        player.ApplyWindyWeatherEffects();
    }
}

// �÷��̾� Ŭ����
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

    // �پ��� ������ ���� ȿ�� �޼����...
    public void ApplyClearWeatherEffects() { /* ... */ }
    public void ApplyRainyWeatherEffects() { /* ... */ }
    public void ApplyWindyWeatherEffects() { /* ... */ }
}