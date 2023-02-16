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
    Autumn, 
}
public class ClimateManagerClass : MonoBehaviour
{
    [Header("Climate, Regional & Seasonal Enums")]
    public Climates climate;
    public Regions regions;
    public Seasons seasons;

    [Header("Temperature Ranges")]
    [SerializeField] private float _freezing = -15.0f;
    [SerializeField] private float _cold =      -5.0f;
    [SerializeField] private float _mild =       0.0f;
    [SerializeField] private float _warm =      15.0f;
    [SerializeField] private float _hot =       30.0f;
    [SerializeField] private float _boiling =   40.0f;

    [Header("Humidity Ranges")]
    [SerializeField] private float _veryLow =   40.0f;
    [SerializeField] private float _low =       55.0f;
    [SerializeField] private float _average =   70.0f;
    [SerializeField] private float _high =      85.0f;
    [SerializeField] private float _veryHigh = 100.0f;

    [Header("Current Climate variables")]
    [SerializeField] private float _climateTempMin;
    [SerializeField] private float _climateTempMax;
    [SerializeField] private float _climateHumMin;
    [SerializeField] private float _climateHumMax;

    [SerializeField] private WindManager _windMan;

    public float TempMin { get => _climateTempMin; set => _climateHumMin = value; }
    public float TempMax { get => _climateTempMax; set => _climateTempMax = value; }
    public float HumMin { get => _climateHumMin; set => _climateHumMin = value; }
    public float HumMax { get => _climateHumMax; set => _climateHumMax = value; }

    private void Awake()
    {

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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 45;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 30;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 15;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;

                                            _windMan.WindMin = 0;
                                            _windMan.WindMax = 30;
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
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
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
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
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
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _low * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _boiling;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;
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
                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _hot * 1.1f;
                                            _climateTempMax = _boiling * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot / 1.1f;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _mild;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm * 1.1f;
                                            _climateTempMax = _hot * 1.1f;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _veryHigh * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild * 1.1f;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high * 1.1f;
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
                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm / 1.1f;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high / 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild / 1.1f;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _low / 1.1f;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _warm;
                                            _climateTempMax = _hot;
                                            _climateHumMin = _average * 1.1f;
                                            _climateHumMax = _high;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _mild;
                                            _climateTempMax = _warm;
                                            _climateHumMin = _average;
                                            _climateHumMax = _high;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low * 1.1f;
                                            _climateHumMax = _average * 1.1f;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold / 1.1f;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low / 1.1f;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild / 1.1f;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average / 1.1f;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _veryLow;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _low;
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
                                            _climateTempMin = _freezing / 1.1f;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Spring):
                                        {
                                            _climateTempMin = _cold / 1.1f;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Summer):
                                        {
                                            _climateTempMin = _cold;
                                            _climateTempMax = _mild;
                                            _climateHumMin = _low;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                    case (Seasons.Autumn):
                                        {
                                            _climateTempMin = _freezing;
                                            _climateTempMax = _cold;
                                            _climateHumMin = _veryLow / 1.1f;
                                            _climateHumMax = _average;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
        }


        /*switch (climate)
        {
            case (Climates.Unspecified):
                {
                    switch (seasons)
                    {
                        case (Seasons.Winter):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _average;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Spring):
                            {
                                _climateTempMin = _mild;
                                _climateTempMax = _hot;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Summer):
                            {
                                _climateTempMin = _boiling;
                                _climateTempMax = _hot;
                                _climateHumMin = _average;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Autumn):
                            {
                                _climateTempMin = _cold;
                                _climateTempMax = _warm;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                    }
                    break;
                }

            case (Climates.Average):
                {
                    switch (seasons)
                    {
                        case (Seasons.Winter):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _average;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Spring):
                            {
                                _climateTempMin = _cold;
                                _climateTempMax = _hot;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Summer):
                            {
                                _climateTempMin = _warm;
                                _climateTempMax = _boiling;
                                _climateHumMin = _average;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Autumn):
                            {
                                _climateTempMin = _cold;
                                _climateTempMax = _hot;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                    }
                    break;
                }

            case (Climates.Desert):
                {
                    switch (seasons)
                    {
                        case (Seasons.Winter):
                            {
                                _climateTempMin = _warm;
                                _climateTempMax = _hot;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _low;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Spring):
                            {
                                _climateTempMin = _warm * 1.1f;
                                _climateTempMax = _boiling;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _low;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Summer):
                            {
                                _climateTempMin = _warm * 1.1f;
                                _climateTempMax = _boiling * 1.1f;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _low;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Autumn):
                            {
                                _climateTempMin = _warm;
                                _climateTempMax = _hot * 1.1f;
                                _climateHumMin = _veryLow;
                                _climateHumMax = _low;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                    }
                    break;
                }

            case (Climates.Tropical):
                {
                    switch (seasons)
                    {
                        case (Seasons.Winter):
                            {
                                _climateTempMin = _warm / 1.1f;
                                _climateTempMax = _hot;
                                _climateHumMin = _average * 1.1f;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Spring):
                            {
                                _climateTempMin = _warm;
                                _climateTempMax = _hot * 1.1f;
                                _climateHumMin = _average;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Summer):
                            {
                                _climateTempMin = _warm;
                                _climateTempMax = _hot * 1.1f;
                                _climateHumMin = _average;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Autumn): 
                            {
                                _climateTempMin = _warm / 1.1f;
                                _climateTempMax = _hot;
                                _climateHumMin = _average * 1.1f;
                                _climateHumMax = _veryHigh;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                    }
                    break;
                }

            case (Climates.Tundra):
                {
                    switch (seasons)
                    {
                        case (Seasons.Winter):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Spring):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _low / 1.1f;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Summer):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _low / 1.1f;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                        case (Seasons.Autumn):
                            {
                                _climateTempMin = _freezing;
                                _climateTempMax = _mild;
                                _climateHumMin = _low;
                                _climateHumMax = _high;

                                //_windMan.WindMin = ;
                                //_windMan.WindMax = ;
                                break;
                            }
                    }
                    break;
                }
        }*/
    }
