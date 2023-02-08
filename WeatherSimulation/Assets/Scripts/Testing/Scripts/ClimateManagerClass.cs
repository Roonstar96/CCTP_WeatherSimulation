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
public enum Seasons
{
    Spring,
    Summer,
    Autumn, 
    Winter
}
public class ClimateManagerClass : MonoBehaviour
{
    [SerializeField] private Climates _climate;
    [SerializeField] private Seasons _seasons;

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

    public float TempMin { get => _climateTempMin; set => _climateHumMin = value; }
    public float TempMax { get => _climateTempMax; set => _climateTempMax = value; }
    public float HumMin { get => _climateHumMin; set => _climateHumMin = value; }
    public float HumMax { get => _climateHumMax; set => _climateHumMax = value; }

    private void Awake()
    {
        switch (_climate)
        {
            case (Climates.Unspecified):
                {
                    _climateTempMin = _freezing;
                    _climateTempMax = _boiling;
                    _climateHumMin = _veryLow;
                    _climateHumMax = _veryHigh;
                    break;
                }
            case (Climates.Average):
                {
                    _climateTempMin = _cold;
                    _climateTempMax = _hot;
                    _climateHumMin = _low;
                    _climateHumMax = _high;
                    break;
                }
            case (Climates.Desert):
                {
                    _climateTempMin = _warm;
                    _climateTempMax = _boiling;
                    _climateHumMin = _veryLow;
                    _climateHumMax = _low;
                    break;
                }
            case (Climates.Tropical):
                {
                    _climateTempMin = _warm;
                    _climateTempMax = _hot;
                    _climateHumMin = _average;
                    _climateHumMax = _veryHigh;
                    break;
                }
            case (Climates.Tundra):
                {
                    _climateTempMin = _freezing;
                    _climateTempMax = _mild;
                    _climateHumMin = _low;
                    _climateHumMax = _high;
                    break;
                }
        }
    }

    private void OnValidate()
    {
        switch (_climate)
        {
            case (Climates.Unspecified):
                {
                    _climateTempMin = _freezing;
                    _climateTempMax = _boiling;
                    _climateHumMin = _veryLow;
                    _climateHumMax = _veryHigh;
                    break;
                }
            case (Climates.Average):
                {
                    _climateTempMin = _cold;
                    _climateTempMax = _hot;
                    _climateHumMin = _low;
                    _climateHumMax = _high;
                    break;
                }
            case (Climates.Desert):
                {
                    _climateTempMin = _warm;
                    _climateTempMax = _boiling;
                    _climateHumMin = _veryLow;
                    _climateHumMax = _low;
                    break;
                }
            case (Climates.Tropical):
                {
                    _climateTempMin = _warm;
                    _climateTempMax = _hot;
                    _climateHumMin = _average;
                    _climateHumMax = _veryHigh;
                    break;
                }
            case (Climates.Tundra):
                {
                    _climateTempMin = _freezing;
                    _climateTempMax = _mild;
                    _climateHumMin = _low;
                    _climateHumMax = _high;
                    break;
                }
        }

        switch (_seasons)
        {
            case (Seasons.Spring):
                {
                    //TEMP INCREASE
                    break;
                }
            case (Seasons.Summer):
                {
                    //HUM & TEMP INCREASE
                    break;
                }
            case (Seasons.Autumn):
                {
                    //TEMP DECREASE
                    break;
                }
            case (Seasons.Winter):
                {
                    //HUM & TEMP DECREASE
                    break;
                }

        }
    }
}
