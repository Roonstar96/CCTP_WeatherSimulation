//AUTHOR: Tane Cotterell-East (Roonstar96)

//SUMMARY: This script is responsible for setting and adjusting the tempurate and humidity of a climate
// as time progresses. There are 2 events that invoked at different times to allow funtions in this script 
// and other to do what they need to. This script also deals with fog which only occours under certain conditions,#
// with the fogs density, the area it covers and the rate at which it dissapates all being determined by
// the temurature, windspee, season, temurature and humidity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalWeatherManager : MonoBehaviour
{
    [Header("Time values")]
    [SerializeField] private float _timeSeconds;
    [SerializeField] private float _timeMinute;
    [SerializeField] private float _timeHour;
    [SerializeField] private float _timeDay;
    [SerializeField] private float _sunRise;
    [SerializeField] private float _sunSet;

    [Header("Climate Variables")]
    [SerializeField] private float _AmbientTemp;
    [SerializeField] private float _Humidity;
    [SerializeField] private float _EvaporationRate;
    [SerializeField] private float tempMin, tempMax;
    [SerializeField] private float humMin, humMax;
    [SerializeField] private CloudManager _cloudMan;
    [SerializeField] private CloudCollisionManager _cloudColl;
    [SerializeField] private ClimateManagerClass _climateMan;
    [SerializeField] private WindManager _windMan;

    [Header("Fog Variables")]
    [SerializeField] private float _fogMultiplier;
    [SerializeField] private float _fogDensity;
    [SerializeField] private float _fogDispersal;
    [SerializeField] private float _fogDuration;
    [SerializeField] private bool _isFoggy;
    [SerializeField] ParticleSystem _fogSystem;

    private ParticleSystem.MainModule _main;
    private ParticleSystem.EmissionModule _eMod;
    private ParticleSystem.ShapeModule _pShape;
    private ParticleSystem.NoiseModule _pNoise;

    public float Tempurature { get => _AmbientTemp; set => _AmbientTemp = value; }
    public float Evaporation { get => _EvaporationRate; set => _EvaporationRate = value; }
    public float FogMultiplier { get => _fogMultiplier; set => _fogMultiplier = value; }
    public CloudManager CloudMan { get => _cloudMan; set => _cloudMan = value; }

    public event MinuteChanged MinuteChangedEvent;
    public delegate void MinuteChanged();
    public event HourChanged HourChangedEvent;
    public delegate void HourChanged();

    void Awake()
    {
        _timeSeconds = 0f;
        _timeMinute = 0f;
        _timeHour = 0f;
        _timeDay = 0f;

        _timeHour = Mathf.Round(_timeHour);
        _timeDay = Mathf.Round(_timeDay);

        tempMin = _climateMan.TempMin;
        tempMax = _climateMan.TempMax;
        humMin = _climateMan.HumMin;
        humMax = _climateMan.HumMax;

        _AmbientTemp = Mathf.Round( Random.Range( tempMin, (tempMax / 2) ) );
        _Humidity = Mathf.Round( Random.Range( humMin, (humMax + (2 * _AmbientTemp) / 10) ) );

        if (_Humidity > humMax)
        {
            _Humidity = humMax;
        }

        if (HourChangedEvent != null)
        {
            HourChangedEvent();
        }
        if (MinuteChangedEvent != null)
        {
            MinuteChangedEvent();
        }

        //Causeing issues if there isn't a cloud within the local weather object to start
        //MinuteChangedEvent += _cloudMan.DurationCountdown;
        //MinuteChangedEvent += _cloudMan.CurrentWaterStored;
        //HourChangedEvent += TempAndHumdityChange;

        _isFoggy = false;
    }

    private void Update()
    {
        TimeChange();
        EvapChange();

        if (_climateMan.Winter || _climateMan.Autumn)
        {
            if (_timeHour > _sunSet || _timeHour < _sunRise)
            {
                Debug.Log("Can't see for the fog!");
                FogManager();
            }
            else
            {
                return;
            }
        }
    }

    //NOTE: This fucniton is resopnsible for keeping track of time. minutes are represented by seconds for testing purposes
    private void TimeChange()
    {
        _timeSeconds += 1 * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale += 60;
        }
        if (_timeSeconds >= 60.0)
        {
            _timeMinute += 1;
            _timeSeconds = 0f;
            MinuteChangedEvent.Invoke();
        }
        if (_timeMinute >= 60.0)
        {
            _timeHour += 1;
            _timeMinute = 0;
            HourChangedEvent.Invoke();
        }
        if (_timeHour >= 24.0)
        {
            _timeDay += 1;
            _timeSeconds = 0f;
            _timeHour = 0f;
        }    
        if (_timeDay >= 7)
        {
            _timeSeconds = 0f;
            _timeHour = 0f;
            _timeDay = 0f;
        }
    }

    //NOTE: This funciton is responsible for changing the Ambient tempurature and Humidity values as the day goes on
    private void TempAndHumdityChange()
    {
        //NOTE: checks if _timeHour is equal or greater than 'Midnight'
        if (_timeHour >= 0)
        {
            if (_timeHour >= _sunRise)
            {
                //NOTE: randomly increase AT by 0% - 20% & H by 0% - 10% of current value untill midday
                if (_timeHour < 12)
                {
                    Mathf.Round(_AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5)));
                    Mathf.Round(_Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
                }
                else
                {
                    AfterMidday();
                }
            }
            //NOTE: randomly increase/decrease AT by 0% - 20% & H by 0% - 10% of current value untill sunrise
            else
            {
                int r2 = Random.Range(0, 1);
                if (r2 != 0)
                {
                    Mathf.Round(_AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5)));
                    Mathf.Round(_Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
                }
                else
                {
                    Mathf.Round(_AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5)));
                    Mathf.Round(_Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
                }
            }
            if (_AmbientTemp < tempMin)
            {
                _AmbientTemp = tempMin;
            }
            else if (_AmbientTemp > tempMax)
            {
                _AmbientTemp = tempMax;
            }
            if (_Humidity < humMin)
            {
                _Humidity = humMin;
            }
            else if(_Humidity > humMax)
            {
                _Humidity = humMax;
            }
        }
    }

    private void AfterMidday()
    {
        //NOTE: randomly decrease AT by 0% - 20% & H by 0% - 10% of current value from sunset untill midnight
        if (_timeHour >= _sunSet)
        {
            Mathf.Round(_AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5)));
            Mathf.Round(_Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
        }
        //NOTE: randomly increase/decrease AT by 0% - 20% & H by 0% - 10% of current value from midday untill sunset 
        else
        {
            int r1 = Random.Range(0, 1);

            if (r1 != 0)
            {
                Mathf.Round(_AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5)));
                Mathf.Round(_Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
            }
            else
            {
                Mathf.Round(_AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5)));
                Mathf.Round(_Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
            }
        }
    }

    private void EvapChange()
    {
        float tempAvg = (tempMin + tempMax) / 2;
        float humAvg = (humMin + humMax) / 2;

        if (_AmbientTemp <= 0)
        {
            _EvaporationRate = 0;
            return;
        }
        if (_AmbientTemp > tempAvg && _Humidity <= humAvg)
        {
            _EvaporationRate = ((_AmbientTemp * _Humidity) / 150);
            return;
        }
        else if (_AmbientTemp <= tempAvg && _Humidity > humAvg)
        {
            _EvaporationRate = ((_AmbientTemp * _Humidity) / 150);
            return;
        }
        else if (_AmbientTemp <= tempAvg && _Humidity <= humAvg)
        {
            _EvaporationRate = ((Mathf.Abs(_AmbientTemp) * _Humidity) / 200);
            return;
        }
        else if (_AmbientTemp > tempAvg && _Humidity > humAvg)
        {
            _EvaporationRate = ((_AmbientTemp * _Humidity) / 100);
            return;
        }
    }

    private void FogManager()
    {
        if (_cloudColl.HasCloud || _AmbientTemp > 5)
        {
            while (_isFoggy)
            {
                _fogDensity -= (_AmbientTemp / 10);

                if (_fogDensity <= 0)
                {
                    _main.startLifetime = 0;
                    _eMod.rateOverTime = 0;
                    _pShape.scale = new Vector3(0, 0, 0);
                    _pNoise.strengthX = 0;
                    _isFoggy = false;

                    _fogSystem.Stop();
                }
            }
            return;
        }
        else
        {
            if (_AmbientTemp <= 5 && _AmbientTemp >= -5)
            {
                _fogDensity = 100 + ((_Humidity * 10) / (_AmbientTemp + 1));
                _fogDensity *= _fogMultiplier;

                float StartLife = 10 * (Mathf.Abs(_AmbientTemp));
                StartLife /= (_fogMultiplier - _windMan.Speed);
                float WindSpeedMulti = _windMan.Speed / 100;

                _main.startLifetime = StartLife;
                _eMod.rateOverTime = _fogDensity;
                _pShape.scale = new Vector3(1 * _fogMultiplier, 0.2f * _fogMultiplier, 1 * _fogMultiplier);
                _pNoise.strengthX = WindSpeedMulti;
                //_pNoise.strengthZ = WindSpeedMulti;
                _isFoggy = true;

                _fogSystem.Play();
            }
        }
    }
}