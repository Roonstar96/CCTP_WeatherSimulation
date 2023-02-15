using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalWeatherManager : MonoBehaviour
{
    [Header("Climate Variables")]
    [SerializeField] private float _AmbientTemp;
    [SerializeField] private float _Humidity;
    [SerializeField] private float _EvaporationRate;
    [SerializeField] private float tempMin, tempMax;
    [SerializeField] private float humMin, humMax;
    [SerializeField] private ClimateManagerClass climateMan;

    [Header("Time values")]
    [SerializeField] private float _timeSeconds;
    [SerializeField] private float _timeHour;
    [SerializeField] private float _timeDay;
    [SerializeField] private float _sunRise;
    [SerializeField] private float _sunSet;

    //public test_CloudManager _cloud;

    public float Tempurature { get => _AmbientTemp; set => _AmbientTemp = value; }
    //public float Humidity { get => _Humidity; set => _Humidity = value; }
    public float Evaporation { get => +_EvaporationRate; set => _EvaporationRate = value; }

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

        //_EvaporationRate = ((_AmbientTemp * _Humidity) / 100 );
    }

    private void Update()
    {
        TimeChange();
        EvapChange();
    }

    //NOTE: This fucniton is resopnsible for keeping track of in games time. minutes are represented by seconds for testing purposes
    private void TimeChange()
    {
        _timeSeconds += 1 * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale += 6;
        }
        if (_timeSeconds >= 60.0)
        {
            _timeHour += 1;
            _timeSeconds = 0f;
            TempAndHumdityChange();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cloud")
        {
            Debug.Log("New Cloud");
            other.GetComponent<test_CloudManager>()._weather = gameObject.GetComponent<LocalWeatherManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cloud")
        {
            Debug.Log("New Cloud");
            other.GetComponent<test_CloudManager>()._weather = null;
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
}