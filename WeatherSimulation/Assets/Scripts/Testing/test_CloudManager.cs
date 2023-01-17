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
    [SerializeField] private float _rainingThreshold;
    [SerializeField] private float _timeTillRain;
    [SerializeField] private float _duration;
    [SerializeField] private float _intensity;
    [SerializeField] private bool _isRaining;
    [SerializeField] private bool _isStoring;

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
        
        _timeTillRain = 0;
        _duration = 0;
        _intensity = 0;

        _isRaining = false;
        _isStoring = false; 

    }

    private void Start()
    {
        if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                Debug.Log("Cloud size Small: " + _cloudSize +
                    "Water stored: " + _waterStored);
                Mathf.Round(_waterStored = (_cloudSize / smallMax) * 100);
                _rainingThreshold = 92;
            }

            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Debug.Log("Cloud size Medium: " + _cloudSize +
                    "Water stored: " + _waterStored);
                Mathf.Round(_waterStored = (_cloudSize / mediumMax) * 100);
                _rainingThreshold = 94;
            }

            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Debug.Log("Cloud size Large: " + _cloudSize +
                    "Water stored: " + _waterStored);
                Mathf.Round(_waterStored = (_cloudSize / largeMax) * 100);
                _rainingThreshold = 96;
            }

            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Debug.Log("Cloud size Huge: " + _cloudSize +
                    "Water stored: " + _waterStored);
                Mathf.Round(_waterStored = (_cloudSize / hugeMax) * 100);
                _rainingThreshold = 98;
            }
        }

        else
        {
            Debug.Log("Cloud size Tiny: " + _cloudSize +
                "Water stored: " + _waterStored);
            Mathf.Round(_waterStored = (_cloudSize / tinyMax) * 100);
            _rainingThreshold = 90;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_isStoring)
        {
            Mathf.Round(_waterStored += (climate._EvaporationRate / 10) * Time.deltaTime);
        }

        if (_isRaining)
        {
            CloudIsRaining(_duration);
        }

        if (_waterStored >= 100 || _waterStored <= 0)
        {
            CurrentWaterStored();
        }

        if (_waterStored >= _rainingThreshold)
        {
            CalculateRainVariables();
        }

        if (_timeTillRain > 0)
        {
            while (_timeTillRain > 0)
            {
                _timeTillRain -= 1 * Time.deltaTime;
            }
            _isStoring = false;
            _isRaining = true;
        }
    }

    void CurrentWaterStored()
    {
        if (_isStoring)
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

        if (_isRaining)
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
        }

    }

    void CalculateRainVariables()
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
            //_timeTillRain = ((_waterStored * climate._AmbientTemp) / 60);
            _timeTillRain = (((_waterStored + _cloudSize )  * climate._AmbientTemp) / 60);
            _intensity = ((_waterStored / _cloudSize) * (climate._AmbientTemp / 10));
            _duration = ((_waterStored / climate._AmbientTemp) * _cloudSize);
        }
    }

    void CloudIsRaining(float time)
    {
        //_cloud = GetComponent<ParticleSystem>();

        while (time > 0)
        {
            _waterStored -= _intensity * Time.deltaTime;
        }

        _duration = 0;
        _isRaining = false;
        _isStoring = true;
    }
}
