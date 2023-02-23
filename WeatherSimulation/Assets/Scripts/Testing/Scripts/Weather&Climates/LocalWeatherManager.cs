using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocalWeatherManager : MonoBehaviour
{
    [Header("Time values")]
    [SerializeField] private float _timeSeconds;
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
    [SerializeField] private ClimateManagerClass climateMan;

    [Header("Fog Variables")]
    [SerializeField] private float _fogDesinity;
    [SerializeField] private float _fogDispersal;
    [SerializeField] private float _fogDuration;
    [SerializeField] private static float _fogMultiplier;
    [SerializeField] ParticleSystem _fogSystem;

    private ParticleSystem.EmissionModule _eMod;
    private ParticleSystem.ShapeModule _pShape;
    private ParticleSystem.NoiseModule _pNoise;
    private ParticleSystem.MainModule _main;

    public float Tempurature { get => _AmbientTemp; set => _AmbientTemp = value; }
    public float Evaporation { get => _EvaporationRate; set => _EvaporationRate = value; }
    public static float FogMultiplier { get => _fogMultiplier; set => _fogMultiplier = value; }

    //Add events here for hour change
    public delegate void TimeChanged();
    public static event TimeChanged TimeChangedEvent;

    private void OnEnable()
    {
        //Event.TimeChangeEvent += TempAndHumdityChange;
    }
    private void OnDisable()
    {
        
    }

    void Awake()
    {
        _timeSeconds = 0f;
        _timeHour = 0f;
        _timeDay = 0f;

        _timeHour = Mathf.Round(_timeHour);
        _timeDay = Mathf.Round(_timeDay);

        tempMin = climateMan.TempMin;
        tempMax = climateMan.TempMax;
        humMin = climateMan.HumMin;
        humMax = climateMan.HumMax;

        _AmbientTemp = Mathf.Round( Random.Range( tempMin, (tempMax / 2) ) );
        _Humidity = Mathf.Round( Random.Range( humMin, (humMax + (2 * _AmbientTemp) / 10) ) );

        if (_Humidity > humMax)
        {
            _Humidity = humMax;
        }
    }

    private void Update()
    {
        TimeChange();
        EvapChange();

        if (climateMan.Winter || climateMan.Autumn)
        {
            if (!CloudCollisionManager.HasCloud)
            {
                FogManager();
            }
        }
    }

    //NOTE: This fucniton is resopnsible for keeping track of in games time. minutes are represented by seconds for testing purposes
    private void TimeChange()
    {
        _timeSeconds += 1 * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale += 60;
        }
        if (_timeSeconds >= 60.0)
        {
            _timeHour += 1;
            _timeSeconds = 0f;
            //TempAndHumdityChange();
        }
        else if (_timeHour >= 23.0)
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
            //NOTE: checks if _timeHour after sunrise
            if (_timeHour >= _sunRise)
            {
                //NOTE: randomly increase AT by 0% - 20% & H by 0% - 10% of current value untill midday
                if (_timeHour < 12)
                {
                    Mathf.Round(_AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5)));
                    Mathf.Round(_Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10)));
                }
                //NOTE: checks if _timeHour after midday
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
            //NOTE: Makes sure AT & H never goes outside the min/max values
            if (_AmbientTemp < tempMin)
            {
                _AmbientTemp = tempMin;
            }
            if (_Humidity < humMin)
            {
                _Humidity = humMin;
            }
            else if (_AmbientTemp > tempMax)
            {
                _AmbientTemp = tempMax;
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

        if (_timeHour >= _sunSet || _timeHour <= _sunRise)
        {
            //add static variable that changes density based on location & region
            _fogDesinity = 100 + _AmbientTemp; // add humidity to this
            _fogDispersal = 0.2f + (_AmbientTemp / 100);
        }
        else
        {
            //make a countdown till it gets below a value then stop
            _fogSystem.Stop();
        }
        

        //if between sunset & sunt rise, make sure this also no cloud(can have a min amount of clouds if climate is big enough but will be stretch goal)
        //check the season, then temperature
        //if cold enough, create fog
        //fog density depends of how close to freezing, size of fog depends on location 
        //fog diserpation depends on wind speed, temperate and time

        //link density to rate over time
        //link fog dispersal to shape module scale 
    }
}