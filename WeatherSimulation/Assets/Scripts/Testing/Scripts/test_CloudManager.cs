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
    [SerializeField] private bool _isSnowing;
    [SerializeField] private bool _isStoring;
    [SerializeField] private bool _isCounting;

    public LocalWeatherManager _weather;
    public ParticleSystem _cloud;

    private ParticleSystem.EmissionModule _eMod;
    private ParticleSystem.ShapeModule _pShape;
    private ParticleSystem.NoiseModule _noise;
    private ParticleSystem.MainModule _main;
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

        _cloud = gameObject.GetComponent<ParticleSystem>();
        _eMod = _cloud.emission;
        _pShape = _cloud.shape;
        _noise = _cloud.noise;
        _main = _cloud.main;

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

    private void Update()
    {
        if (_weather == null)
        {
            Debug.Log("No climate");
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

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Climate")
        {
            Debug.Log("New Climate");
            _weather = collision.gameObject.GetComponent<LocalWeatherManager>();
        }
    }*/

    private void CurrentWaterStored()
    {
        if (_isRaining)
        {
            Mathf.Round(_waterStored -= _intensity * Time.deltaTime);
            //Debug.Log("WaterStored: " + _waterStored);
            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }
        if (_isSnowing)
        {
            Mathf.Round(_waterStored -= _intensity * Time.deltaTime);
            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }
        if (_isStoring)
        {
            Mathf.Round(_waterStored += (_weather.Evaporation / 10) * Time.deltaTime);
            //Debug.Log("WaterStored: " + _waterStored);
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

        else if (_weather.Tempurature > -5 && _weather.Tempurature <= 2 )
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

    private void CountDown()
    { 
        if (_weather.Tempurature < 2 && _weather.Tempurature > -5)
        {
            _timeTillRain -= 0.5f * Time.deltaTime;

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
            _timeTillRain -= 1 * Time.deltaTime;

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

    private void CloudIsRaining()
    {
        _duration -= 1 * Time.deltaTime;
        _eMod.rateOverTime = (_rateMulti * _intensity) / 10;

        //TODO: SET MATERIAL
        _noise.strength = 0;
        _noise.frequency = 0;
        _noise.scrollSpeed = 0;
        _noise.octaveCount = 0;
        _main.startSpeed = 20;
        _main.startLifetime = 5;

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

    private void CloudIsSnowing()
    {
        _duration -= 1 * Time.deltaTime;
        _eMod.rateOverTime = (_rateMulti * _intensity) / 10;
        //TODO: SET MATERIAL
        _noise.strength = 5;
        _noise.frequency = 0.5f;
        _noise.scrollSpeed = 1;
        _noise.octaveCount = 10;

        if(_weather.Tempurature <= 2 && _weather.Tempurature >= 0)
        {
            _main.startSpeed = 1;
            _main.startLifetime = 20;
        }
        else
        {
            _main.startSpeed = Mathf.Abs(_weather.Tempurature);
            _main.startLifetime = 20 - Mathf.Abs(_weather.Tempurature);
        }

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
