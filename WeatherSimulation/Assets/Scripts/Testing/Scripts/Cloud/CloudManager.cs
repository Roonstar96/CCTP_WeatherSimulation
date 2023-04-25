//AUTHOR: Tane Cotterell-East (Roonstar96)

//SUMMARY: This script is responsible all functions of a single cloud. The cloud will store water over
//time, with the amount being determined by an Evaporation (calulated using the current tempurature
//and humidity). When the clouds water capacity reaches a certain amount (dependant on cloud size),
//a countdown will initate, at the end of which it will begin to either rain or snow, depending
//on the tempurature. How long it rains/snows for will also depend on the clouds size and the current tempurature

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [Header("Cloud Size Catagories")]
    [SerializeField] private int tinyMin, tinyMax;
    [SerializeField] private int smallMin, smallMax;
    [SerializeField] private int mediumMin, mediumMax;
    [SerializeField] private int largeMin, largeMax;
    [SerializeField] private int hugeMin, hugeMax;

    [Header("Current Cloud status")]
    [SerializeField] private float _cloudSize;
    [SerializeField] private float _waterStored;
    [SerializeField] private float _rainingThreshold;
    [SerializeField] private float _timeTillRain;
    [SerializeField] private float _duration;
    [SerializeField] private float _intensity;
    [SerializeField] private float _rateMulti;

    [Header("Cloud status booleans")]
    [SerializeField] private bool _isStoring;
    [SerializeField] private bool _isCounting;
    [SerializeField] private bool _isRaining;
    [SerializeField] private bool _isSnowing;

    [Header("Manager and System references")]
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private LocalWeatherManager _weather;
    [SerializeField] private WindManager _wind;
    [SerializeField] private ParticleSystem _cloud;
    [SerializeField] private ParticleSystem _lightning;
    [SerializeField] private ParticleSystemRenderer _render;
    [SerializeField] private Material _rainMat;
    [SerializeField] private Material _snowMat;

    private ParticleSystem.MainModule _main;
    private ParticleSystem.EmissionModule _eMod;
    private ParticleSystem.ShapeModule _pShape;
    private ParticleSystem.NoiseModule _noise;
    private float _pScaler;

    public LocalWeatherManager WeatherMan { get => _weather; set => _weather = value; }
    public WindManager WindMan { get => _wind; set => _wind = value; }
    public bool Storing { get => _isStoring; set => _isStoring = value; }
    public bool Raining { get => _isRaining; set => _isRaining = value; }
    public float Size { get => _cloudSize; set => _cloudSize = value; }

    private void Awake()
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

        _main = _cloud.main;
        _eMod = _cloud.emission;
        _pShape = _cloud.shape;
        _noise = _cloud.noise;

        _pScaler = 10 * (1 + (_cloudSize / 100));
        _pShape.scale = new Vector3(_pScaler, _pScaler, 1);
        
        _isRaining = false;
        _isSnowing = false;
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
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / mediumMax) * 100);
                _rainingThreshold = 94;
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / largeMax) * 100);
                _rainingThreshold = 96;
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / hugeMax) * 100);
                _rainingThreshold = 98;
            }
        }
        else
        {
            Mathf.Round(_waterStored = (_cloudSize / tinyMax) * 100);
            _rainingThreshold = 90;
        }
    }

    private void Update()
    {
        if (_weather == null)
        {
            _duration = 0;
            _intensity = 0;

            _isRaining = false;
            _isSnowing = false;
            _isCounting = false;

            _cloud.Stop();
            return;
        }
        else
        {
            CloudIsMoving();

            if (_cloudSize == 1 && _waterStored <= 0)
            {
                Debug.Log("No more water, no more cloud!");
                Destroy(gameObject);
            }
            if (_isStoring)
            {
                CurrentWaterStored();
            }
            if (_isCounting)
            {
                Debug.Log("Coiunting down!");
                CountDown();
            }
            if (_isRaining)
            {
                Debug.Log("It's Raining!");
                CloudIsRaining();
            }
            if (_isSnowing)
            {
                Debug.Log("It's Snowing!");
                CloudIsSnowing();
            }
        }
    }

    private void CloudIsMoving()
    {
        float breeze = _cloudSize / _wind.Speed;
        

    }

    public void CurrentWaterStored()
    {
        if (_isRaining)
        {
            Mathf.Round(_waterStored -= _intensity);
            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }
        if (_isSnowing)
        {
            Mathf.Round(_waterStored -= _intensity);
            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }
        if (_isStoring)
        {
            Mathf.Round(_waterStored += (_weather.Evaporation / 10));
            if (_weather.Tempurature <= 2)
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
    }

    private void CalculateRainVariables()
    {
        if (_weather.Tempurature < -5)
        {
            Mathf.Round(_timeTillRain = 0);
            Mathf.Round(_intensity = 0);
            Mathf.Round(_duration = 0);
            _isCounting = false;

            return;
        }
        else if (_weather.Tempurature <= 2 || _weather.Tempurature >= -5)
        {
            float snowMultiplier = (Mathf.Abs(_weather.Tempurature) / 100) + 1;

            Mathf.Round(_intensity = ((_waterStored / _cloudSize) / Mathf.Abs(_weather.Tempurature) / 5));
            Mathf.Round(_duration = ((_waterStored / Mathf.Abs(_weather.Tempurature)) * _cloudSize));
            Mathf.Round(_duration = _duration * snowMultiplier);
            _isSnowing = true;
            _isStoring = false;
        }
        else
        {
            if (_cloudSize == 100)
            {
                Mathf.Round(_intensity = ((_waterStored / _cloudSize) / Mathf.Abs(_weather.Tempurature) / 10));
                Mathf.Round(_duration = ((_waterStored / Mathf.Abs(_weather.Tempurature)) * _cloudSize));
                _isRaining = true;
                _isStoring = false;
            }
            else
            {
                Debug.Log("Setting Variables & counting down");
                Mathf.Round(_timeTillRain = (((_waterStored + _cloudSize) * Mathf.Abs(_weather.Tempurature)) / 60));
                Mathf.Round(_intensity = ((_waterStored / _cloudSize) / (Mathf.Abs(_weather.Tempurature) / 10)));
                Mathf.Round(_duration = ((_waterStored / Mathf.Abs(_weather.Tempurature)) * _cloudSize));
                _isCounting = true;
            }
        }
    }

    public void CountDown()
    { 
        if (_weather.Tempurature < 2 && _weather.Tempurature > -5)
        {
            _timeTillRain -= 0.5F;

            if (_timeTillRain <= 0)
            {
                _timeTillRain = 0;
                _isRaining = false;
                _isSnowing = true;
                _isStoring = false;
                _isCounting = false;
            }
        }
        else if (_weather.Tempurature > 2)
        {
            _timeTillRain -= 1;

            if (_timeTillRain <= 0)
            {
                _timeTillRain = 0;
                _isRaining = true;
                _isSnowing = false;
                _isStoring = false;
                _isCounting = false;
            }
        }
    }

    public void DurationCountdown()
    {
        if (_isRaining || _isSnowing)
        {
            _duration -= 1;
        }
        else
        {
            return;
        }
    }

    private void CloudIsRaining()
    {
        _eMod.rateOverTime = (_rateMulti * _intensity) / 10;

        _render.material = _rainMat;
        _noise.strength = 0;
        _noise.frequency = 0;
        _noise.scrollSpeed = 0;
        _noise.octaveCount = 0;
        _main.startSpeed = 25;
        _main.startLifetime = 5;

        _cloud.Play();

        if (_duration <= 0)
        {
            _cloud.Stop();
            _duration = 0;
            _intensity = 0;

            _isStoring = true;
            _isRaining = false;
            _isCounting = false;
        }
    }

    private void CloudIsSnowing()
    {
        _eMod.rateOverTime = (_rateMulti * _intensity) / 10;

        _render.material = _snowMat;
        _noise.strength = 5;
        _noise.frequency = 0.5f;
        _noise.scrollSpeed = 1;
        _noise.octaveCount = 10;

        if(_weather.Tempurature <= 2 && _weather.Tempurature >= 0)
        {
            _main.startSpeed = 1;
            _main.startLifetime = 25;
        }
        else
        {
            _main.startLifetime = 20 - Mathf.Abs(_weather.Tempurature);
        }

        _cloud.Play();

        if (_duration <= 0)
        {
            _cloud.Stop();
            _duration = 0;
            _intensity = 0;

            _isStoring = true;
            _isRaining = false;
            _isCounting = false;
        }
    }

    private void CloudSizeIncrease()
    {
        _cloudSize += 1;
        _rateMulti = 100 + _cloudSize;

        _pScaler = 10 * (1 + (_cloudSize / 100));
        _pShape.scale = new Vector3(_pScaler, _pScaler, 1);

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
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 92;
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 94;
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 96;
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Mathf.Round(_waterStored = 0);
                _rainingThreshold = 98;
            }
        }
        else
        {
            Mathf.Round(_waterStored = 0);
            _rainingThreshold = 90;
        }
    }

    private void CloudSizeDecrease()
    {
        _cloudSize -= 1;
        _rateMulti = 100 + _cloudSize;

        _pScaler = 10 * (1 + (_cloudSize / 100));
        _pShape.scale = new Vector3(_pScaler, _pScaler, 1);

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
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 92;
            }
            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 94;
            }
            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 96;
            }
            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Mathf.Round(_waterStored = 100);
                _rainingThreshold = 98;
            }
        }
        else
        {
            Mathf.Round(_waterStored = 100);
            _rainingThreshold = 90;
        }
    }
}
