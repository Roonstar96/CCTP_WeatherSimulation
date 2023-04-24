//AUTHOR: Tane Cotterell-East (Roonstar96)

//SUMMARY: This script is responsible for adjusting the Min/Max variables for Ambient Temperature,
//Humidity, wind speed and for setting the value of a Fog Multiplier all for the LocalWeatherManager script.
//These values are all based on the Climate, Region, and Season to try and replicate behaviour of
//weather in the real world as accurately as possible

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Climates
{
    Unspecified,
    Average,
    Desert,
    Tropical,
    Tundra
}
public enum Regions
{
    Coastal,
    Island,
    Mountains,
    Plains
}
public enum Seasons
{
    Winter,
    Spring,
    Summer,
    Autumn 
}
public class ClimateManagerClass : MonoBehaviour
{
    [Header("Climate, Regional & Seasonal Enums")]
    public Climates climate;
    public Regions regions;
    public Seasons seasons;

    private bool _isWinter;
    private bool _isSpring;
    private bool _isSummer;
    private bool _isAutumn;

    [Header("Temperature Ranges")]
    [SerializeField] private float _freezing = -15.0f;
    [SerializeField] private float _cold = -5.0f;
    [SerializeField] private float _mild = 0.0f;
    [SerializeField] private float _warm = 15.0f;
    [SerializeField] private float _hot = 30.0f;
    [SerializeField] private float _boiling = 40.0f;

    [Header("Humidity Ranges")]
    [SerializeField] private float _veryLow = 40.0f;
    [SerializeField] private float _low = 55.0f;
    [SerializeField] private float _average = 70.0f;
    [SerializeField] private float _high = 85.0f;
    [SerializeField] private float _veryHigh = 100.0f;

    [Header("Current Climate variables")]
    [SerializeField] private float _climateTempMin;
    [SerializeField] private float _climateTempMax;
    [SerializeField] private float _climateHumMin;
    [SerializeField] private float _climateHumMax;

    [Header("Manager References")]
    [SerializeField] private LocalWeatherManager _localWeather;
    [SerializeField] private WindManager _windMan;

    public float TempMin { get => _climateTempMin; set => _climateHumMin = value; }
    public float TempMax { get => _climateTempMax; set => _climateTempMax = value; }
    public float HumMin { get => _climateHumMin; set => _climateHumMin = value; }
    public float HumMax { get => _climateHumMax; set => _climateHumMax = value; }

    public bool Winter { get => _isWinter; set => _isWinter = value; }
    public bool Spring { get => _isSpring; set => _isSpring = value; }
    public bool Summer { get => _isSummer; set => _isSummer = value; }
    public bool Autumn { get => _isAutumn; set => _isAutumn = value; }

    private void Awake()
    {
        switch (climate)
        {
            case (Climates.Unspecified):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1;
                                            _windMan.WindAdjustment = 1.55f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Average):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.55f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Desert):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.75f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.75f;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _low * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.75f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.75f;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.5f;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.5f;
                                            _windMan.WindAdjustment = 1.2f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0.5f;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 0.5f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0.5f;
                                            _windMan.WindAdjustment = 0.75f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Tropical):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.2f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.2f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm / 1.1f;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high / 1.1f;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.2f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.05f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Tundra):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 1.25f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.25f;
                                            _windMan.WindAdjustment = 1.4f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 1.25f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.15f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.25f;
                                            _windMan.WindAdjustment = 1.4f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold / 1.1f;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low / 1.1f;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.6f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild / 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.4f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.3f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold / 1.1f;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            _windMan.WindAdjustment = 1;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            _windMan.WindAdjustment = 1.2f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
        }
    }

    private void OnValidate()
    {
        switch (climate)
        {
            case (Climates.Unspecified):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            //Add fog multiplier adjustments here, but only for costal, island, Average & tropical.
                                            //They can only be in winter & autumn
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;



                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Average):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 45;

                                            _localWeather.FogMultiplier = 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Desert):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.75f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.75f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _low * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.75f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.75f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Tropical):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh * 1.1f;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.5f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm / 1.1f;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high / 1.1f;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 25;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 15;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case (Climates.Tundra):
                {
                    switch (regions)
                    {
                        case (Regions.Coastal):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 1.25f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Island):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 1.25f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.25f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Mountains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold / 1.1f;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low / 1.1f;

                                            _windMan.WindMin = 15;
                                            _windMan.WindMax = 50;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild / 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 35;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;

                                            _windMan.WindMin = 10;
                                            _windMan.WindMax = 40;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                        case (Regions.Plains):
                            {
                                switch (seasons)
                                {
                                    case (Seasons.Winter):
                                        {
                                            _isWinter = true;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 30;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _isWinter = false;
                                            _isSpring = true;
                                            _isSummer = false;
                                            _isAutumn = false;

                                            _climateTempMin = _cold / 1.1f;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = true;
                                            _isAutumn = false;

                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 1;
                                            _windMan.WindMax = 10;

                                            _localWeather.FogMultiplier = 0;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _isWinter = false;
                                            _isSpring = false;
                                            _isSummer = false;
                                            _isAutumn = true;

                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 5;
                                            _windMan.WindMax = 20;

                                            _localWeather.FogMultiplier = 1.1f;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
        }
    }
}
