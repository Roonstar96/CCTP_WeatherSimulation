using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CloudManager : MonoBehaviour
{
    //[Header("Cloud Size Catagories")]
    [SerializeField] private int tinyMin, tinyMax;
    [SerializeField] private int smallMin, smallMax;
    [SerializeField] private int mediumMin, mediumMax;
    [SerializeField] private int largeMin, largeMax;
    [SerializeField] private int hugeMin, hugeMax;

    [SerializeField] private float _cloudSize;
    [SerializeField] private float _waterStored;
    [SerializeField] private float _rainingThreshold;
    [SerializeField] private float _timeTillRain;
    [SerializeField] private float _duration;
    [SerializeField] private float _intensity;
    [SerializeField] private float _rateMulti;

    [SerializeField] private bool _isRaining;
    [SerializeField] private bool _isStoring;
    [SerializeField] private bool _isCounting;

    [SerializeField] public LocalWeatherManager climate;
    [SerializeField] private ParticleSystem _cloud;

    private ParticleSystem.EmissionModule _eMod;
    private ParticleSystem.ShapeModule _pShape;
    private float _pScaler;

    // Start is called before the first frame update
    void Awake()
    {
        tinyMin = 1;
        tinyMax = 20;
        smallMin = 21;
        smallMax = 40;
        mediumMin = 41;
        mediumMax = 60;
        largeMin = 61;
        largeMax = 80;
        hugeMin = 81;
        hugeMax = 100;

        Mathf.Round(_cloudSize = Random.Range(tinyMin, hugeMax));

        _timeTillRain = 0;
        _duration = 0;
        _intensity = 0;

        _rateMulti = 100 + _cloudSize;
        _pScaler = 1 + (_cloudSize / 100);
        _pScaler = 10 * _pScaler;

        _isRaining = false;
        _isStoring = true;
        _isCounting = false;
    }

    private void Start()
    {
        if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / smallMax) * 100);
                _rainingThreshold = 92;
                //Debug.Log("Cloud size Small: " + _cloudSize + "Water stored: " + _waterStored);
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / mediumMax) * 100);
                _rainingThreshold = 94;
                //Debug.Log("Cloud size Medium: " + _cloudSize + "Water stored: " + _waterStored);
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / largeMax) * 100);
                _rainingThreshold = 96;
                //Debug.Log("Cloud size Large: " + _cloudSize + "Water stored: " + _waterStored);
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / hugeMax) * 100);
                _rainingThreshold = 98;
                //Debug.Log("Cloud size Huge: " + _cloudSize + "Water stored: " + _waterStored);
            }
        }
        else
        {
            Mathf.Round(_waterStored = (_cloudSize / tinyMax) * 100);
            _rainingThreshold = 90;
            //Debug.Log("Cloud size Tiny: " + _cloudSize + "Water stored: " + _waterStored);
        }

    }
    void Update()
    {
        CurrentWaterStored();
        //Debug.Log("WaterStored: " + _waterStored);

        if (_isCounting)
        {
            RainCountDown();
        }
        if (_isRaining)
        {
            CloudIsRaining();
        }
    }

    void CurrentWaterStored()
    {
        if (_isStoring)
        {
            Mathf.Round(_waterStored += (climate._EvaporationRate / 10 * Time.deltaTime));
            //Debug.Log("WaterStored: " + _waterStored);
            if (climate._AmbientTemp <= 0)
            {
                CalculateRainVariables();
            }
            if (_waterStored >= _rainingThreshold && !_isCounting)
            {
                CalculateRainVariables();
            }
            if (_waterStored >= 100)
            {
                CloudSizeIncrease();
            }
        }
        if (_isRaining)
        {
            Mathf.Round(_waterStored -= _intensity * Time.deltaTime);
            //Debug.Log("WaterStored: " + _waterStored);
            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }
    }

    void CalculateRainVariables()
    {
        if (_cloudSize == 100)
        {
            Mathf.Round(_intensity = ((_waterStored / _cloudSize) / (climate._AmbientTemp / 10)));
            Mathf.Round(_duration = ((_waterStored / climate._AmbientTemp) * _cloudSize));
            _isRaining = true;
            _isStoring = false;
        }
        else
        {
            //Debug.Log("Setting Variables & counting down");
            Mathf.Round(_timeTillRain = (((_waterStored + _cloudSize) * climate._AmbientTemp) / 60));
            Mathf.Round(_intensity = ((_waterStored / _cloudSize) / (climate._AmbientTemp / 10)));
            Mathf.Round(_duration = ((_waterStored / climate._AmbientTemp) * _cloudSize));
            _isCounting = true;
        }
    }

    void RainCountDown()
    {
        _timeTillRain -= 1 * Time.deltaTime;

        if (_timeTillRain <= 0)
        {
            _timeTillRain = 0;
            _isRaining = true;
            _isStoring = false;
            _isCounting = false;
        }
    }

    void CloudIsRaining()
    {
        _duration -= 1 * Time.deltaTime;
        _eMod = _cloud.emission;
        _eMod.rateOverTime = _rateMulti * _intensity;
        //Debug.Log("Rate over item: " + eMod);
        _cloud.Play();

        if (_duration <= 0)
        {
            //Debug.Log("Rain has stopped");
            _cloud.Stop();
            _duration = 0;
            _intensity = 0;

            _isStoring = true;
            _isRaining = false;
            _isCounting = false;
        }
    }

    void CloudSizeIncrease()
    {
        _cloudSize += 1;
        _rateMulti = 100 + _cloudSize;

        if (_cloudSize >= hugeMax)
        {
            _cloudSize = hugeMax;
            Mathf.Round(_waterStored = 0);
            _rainingThreshold = 98;
        }
        else if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                //Debug.Log("Cloud size Small: " + _cloudSize);
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 92;
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                //Debug.Log("Cloud size Medium: " + _cloudSize);
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 94;
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                //Debug.Log("Cloud size Large: " + _cloudSize);
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 96;
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                //Debug.Log("Cloud size Huge: " + _cloudSize);
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 98;
            }
        }
        else
        {
            //Debug.Log("Cloud size Tiny: " + _cloudSize);
            Mathf.Round(_waterStored = 0);
            _rainingThreshold = 90;
        }
    }

    void CloudSizeDecrease()
    {
        _cloudSize -= 1;
        _rateMulti = 100 + _cloudSize;

        if (_cloudSize <= tinyMin)
        {
            _cloudSize = tinyMin;
            Mathf.Round(_waterStored = 100);
            _rainingThreshold = 90;
        }
        else if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                //Debug.Log("Cloud size Small: " + _cloudSize);
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 92;
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                //Debug.Log("Cloud size Medium: " + _cloudSize);
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 94;
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                //Debug.Log("Cloud size Large: " + _cloudSize);
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 96;
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                //Debug.Log("Cloud size Huge: " + _cloudSize);
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 98;
            }
        }
        else
        {
            //Debug.Log("Cloud size Tiny: " + _cloudSize);
            Mathf.Round(_waterStored = 100);
            _rainingThreshold = 90;
        }
    }
}
