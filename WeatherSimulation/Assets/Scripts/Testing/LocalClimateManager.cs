using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalClimateManager : MonoBehaviour
{
    //public enum Climates { Desert, Tundra, Rainforest, Grassland}
    //public Climates _climates; 

    [SerializeField] private float _AmbientTemp;
    [SerializeField] private float _Humidity;
    [SerializeField] private float _EvaporationRate;

    [SerializeField] private float _timeSeconds;
    [SerializeField] private float _timeHour;
    [SerializeField] private float _timeDay;

    [SerializeField] private float _sunRise;
    [SerializeField] private float _sunSet;

    [SerializeField] private float tempMin, tempMax;
    private float humMin, humMax;

    UnityEvent hourChangeEvent;
    UnityEvent tempChangeEvent;

    void Awake()
    {
        _timeSeconds = 0f;
        _timeHour = 0f;
        _timeDay = 0f;

        _timeHour = Mathf.Round(_timeHour);
        _timeDay = Mathf.Round(_timeDay);

        tempMin = 0f;
        tempMax = 40f;

        humMin = 30f;
        humMax = 90f;

        _AmbientTemp = Mathf.Round( Random.Range( tempMin, (tempMax / 2) ) );
        _Humidity = Mathf.Round( Random.Range( humMin, (humMax + _AmbientTemp / 10) ) );

        if (_Humidity > humMax)
        {
            _Humidity = humMax;
        }

        _EvaporationRate = Mathf.Round( ( (_AmbientTemp * _Humidity) / 100 ) );

        if (hourChangeEvent == null)
        {
            hourChangeEvent = new UnityEvent();
        }

        hourChangeEvent.AddListener(TempAndHumdityChange);
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
            hourChangeEvent.Invoke();
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

                //NOTE: checks if _timeHour after midday
                if (_timeHour >= 12)
                {

                    //NOTE: randomly decrease AT by 0% - 20% & H by 0% - 10% of current value from sunset untill midnight
                    if (_timeHour >= _sunSet)
                    {
                        _AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5));
                        _Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
                    }

                    //NOTE: randomly increase/decrease AT by 0% - 20% & H by 0% - 10% of current value from midday untill sunset 
                    else
                    {
                        int r1 = Random.Range(0, 1);

                        if (r1 != 0)
                        {
                            _AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5));
                            _Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
                        }

                        else
                        {
                            _AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5));
                            _Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
                        }
                    }
                }

                //NOTE: randomly increase AT by 0% - 20% & H by 0% - 10% of current value untill midday
                else
                {
                    _AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5));
                    _Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
                }
            }

            //NOTE: randomly increase/decrease AT by 0% - 20% & H by 0% - 10% of current value untill sunrise
            else
            {
                int r2 = Random.Range(0, 1);

                if (r2 != 0)
                {
                    _AmbientTemp = _AmbientTemp + Random.Range(0, (_AmbientTemp / 5));
                    _Humidity = _Humidity + (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
                }

                else
                {
                    _AmbientTemp = _AmbientTemp - Random.Range(0, (_AmbientTemp / 5));
                    _Humidity = _Humidity - (Random.Range(0, (_Humidity / 10)) + (_AmbientTemp / 10));
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


    private void EvapChange()
    {
        _EvaporationRate = ((_AmbientTemp * _Humidity) / 100);
    }

}
