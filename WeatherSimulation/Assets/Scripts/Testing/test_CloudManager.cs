using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CloudManager : MonoBehaviour
{
    //public enum CloudProperties { Tiny, Small, Medium, Large, Huge }
    //public CloudProperties _cloudProperties;

    //NOTE(Tane) variables for min & max size per catagory including thier unique down pour threshold
    [SerializeField] private int tinyMin, tinyMax;
    [SerializeField] private int smallMin, smallMax;
    [SerializeField] private int mediumMin, mediumMax;
    [SerializeField] private int largeMin, largeMax;
    [SerializeField] private int hugeMin, hugeMax;

    //NOTE(Tane) Variables that are based on the clouds current size
    [SerializeField] private float _cloudSize;
    [SerializeField] private float _waterStored;
    [SerializeField] private float _waterIncrease;
    [SerializeField] private float _rainingThreshold;
    [SerializeField] private float _timeTillRain;
    [SerializeField] private float _duration;
    [SerializeField] private float _intensity;

    [SerializeField] private bool _isRaining;
    [SerializeField] private bool _isStoring;
    [SerializeField] private bool _isCounting;

    [SerializeField] public LocalClimateManager climate;
    //[SerializeField] private ParticleSystem _cloud;

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
        Mathf.Round(_waterIncrease = (climate._EvaporationRate / 10));
        
        _timeTillRain = 0;
        _duration = 0;
        _intensity = 0;
      
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
                Debug.Log("Cloud size Small: " + _cloudSize + "Water stored: " + _waterStored);
            }

            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / mediumMax) * 100);
                _rainingThreshold = 94;
                Debug.Log("Cloud size Medium: " + _cloudSize + "Water stored: " + _waterStored);
            }

            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / largeMax) * 100);
                _rainingThreshold = 96;
                Debug.Log("Cloud size Large: " + _cloudSize + "Water stored: " + _waterStored);
            }

            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Mathf.Round(_waterStored = (_cloudSize / hugeMax) * 100);
                _rainingThreshold = 98;
                Debug.Log("Cloud size Huge: " + _cloudSize + "Water stored: " + _waterStored);
            }
        }

        else
        {
            Mathf.Round(_waterStored = (_cloudSize / tinyMax) * 100);
            _rainingThreshold = 90;
            Debug.Log("Cloud size Tiny: " + _cloudSize + "Water stored: " + _waterStored);
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        Mathf.Round(_waterStored += _waterIncrease * Time.deltaTime);

        CurrentWaterStored();

        if (_isStoring)
        {
            Debug.Log("WaterStored: " + _waterStored);
            /*if (_waterStored >= _rainingThreshold && !_isCounting)
            {
                CalculateRainVariables();
            }

            if (_waterStored >= 100)
            {
                CloudSizeIncrease();
            }*/
        }

        if (_isRaining)
        {
            Mathf.Round(_waterStored -= _intensity * Time.deltaTime);

            if (_waterStored <= 0)
            {
                //CloudSizeDecrease();
            }
        }

        /*if (_timeTillRain > 0)
        {
            RainCountDown();
        }

        if (_isRaining)
        {
            StartCoroutine(CloudIsRaining(_duration));
        }

        if (_waterStored >= _rainingThreshold)
        {
            CalculateRainVariables();
        }*/
    }

    void CurrentWaterStored()
    {
        if (_isStoring)
        {
            Debug.Log("WaterStored: " + _waterStored);
            /*if (_waterStored >= _rainingThreshold && !_isCounting)
            {
                CalculateRainVariables();
            }

            if (_waterStored >= 100)
            {
                CloudSizeIncrease();
            }*/
        }

       /* while (!_isStoring && _isRaining)
        {
            Mathf.Round(_waterStored -= _intensity * Time.deltaTime);

            if (_waterStored <= 0)
            {
                CloudSizeDecrease();
            }
        }*/
    }

    /*void CalculateRainVariables()
    {
        if (_cloudSize == 100)
        {
            _intensity = ((_waterStored / _cloudSize) * (climate._AmbientTemp / 10));
            _duration = ((_waterStored / climate._AmbientTemp) * _cloudSize);
            _isRaining = true;
            _isStoring = false;
        }

        else
        {
            Debug.Log("Setting Variables & counting down");

            _timeTillRain = (((_waterStored + _cloudSize) * climate._AmbientTemp) / 60);
            _intensity = ((_waterStored / _cloudSize) * (climate._AmbientTemp / 10));
            _duration = ((_waterStored / climate._AmbientTemp) * _cloudSize);

            _isCounting = true;

            //RainCountDown();
        }
    }
    void RainCountDown()
    {
        while (_timeTillRain > 0)
        {
            _timeTillRain -= 1 * Time.deltaTime;
        }

        if (_timeTillRain <= 0)
        {
            _timeTillRain = 0;
            _isRaining = true;
            _isStoring = false;
            _isCounting = false;
        }
    }

    IEnumerator CloudIsRaining(float time)
    {
        //TODO: adjust particle system parameters using intesity
        //
        //_cloud = GetComponent<ParticleSystem>();

        /*while (time > 0)
        {
            time -= 1 * Time.deltaTime;
        }

        yield return new WaitForSeconds(time);

        _duration = 0;
        _intensity = 0;

        _isStoring = true;
        _isRaining = false;
        _isCounting = false;
    }

    void CloudSizeIncrease()
    {
        _cloudSize += 1;

        if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                Debug.Log("Cloud size Small: " + _cloudSize);
                _waterStored = 0;
                _rainingThreshold = 92;
            }

            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Debug.Log("Cloud size Medium: " + _cloudSize);
                _waterStored = 0;
                _rainingThreshold = 94;
            }

            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Debug.Log("Cloud size Large: " + _cloudSize);
                _waterStored = 0;
                _rainingThreshold = 96;
            }

            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Debug.Log("Cloud size Huge: " + _cloudSize);
                _waterStored = 0;
                _rainingThreshold = 98;
            }
        }

        else
        {
            Debug.Log("Cloud size Tiny: " + _cloudSize);
            _waterStored = 0;
            _rainingThreshold = 90;
        }
    }

    void CloudSizeDecrease()
    {
        _cloudSize -= 1;

        if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                Debug.Log("Cloud size Small: " + _cloudSize);
                _waterStored = 100;
                _rainingThreshold = 92;
            }

            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Debug.Log("Cloud size Medium: " + _cloudSize);
                _waterStored = 100;
                _rainingThreshold = 94;
            }

            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Debug.Log("Cloud size Large: " + _cloudSize);
                _waterStored = 100;
                _rainingThreshold = 96;
            }

            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Debug.Log("Cloud size Huge: " + _cloudSize);
                _waterStored = 100;
                _rainingThreshold = 98;
            }
        }

        else
        {
            Debug.Log("Cloud size Tiny: " + _cloudSize);
            _waterStored = 100;
            _rainingThreshold = 90;
        }
    }*/
}
