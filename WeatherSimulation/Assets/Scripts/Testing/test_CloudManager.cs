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
    [SerializeField] private int _timeTillRain;
    [SerializeField] private int _duration;
    [SerializeField] private int _intensity;
    [SerializeField] private bool _isRaining;

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

        _cloudSize = Random.Range(tinyMin, hugeMax);

    }

    private void Start()
    {
        if (_cloudSize > tinyMax)
        {
            if (_cloudSize >= smallMin && _cloudSize <= smallMax)
            {
                Debug.Log("Cloud size Small: " + _cloudSize);
                _waterStored = (_cloudSize / smallMax) * 100;
                Debug.Log("Water stored: " + _waterStored);
            }

            else if (_cloudSize >= mediumMin && _cloudSize <= mediumMax)
            {
                Debug.Log("Cloud size Medium: " + _cloudSize);
                _waterStored = (_cloudSize / mediumMax) * 100;
                Debug.Log("Water stored: " + _waterStored);
            }

            else if (_cloudSize >= largeMin && _cloudSize <= largeMax)
            {
                Debug.Log("Cloud size Large: " + _cloudSize);
                _waterStored = (_cloudSize / largeMax) * 100;
                Debug.Log("Water stored: " + _waterStored);
            }

            else if (_cloudSize >= hugeMin && _cloudSize <= hugeMax)
            {
                Debug.Log("Cloud size Huge: " + _cloudSize);
                _waterStored = (_cloudSize / hugeMax) * 100;
                Debug.Log("Water stored: " + _waterStored);
            }
        }

        else
        {
            Debug.Log("Cloud size Tiny: " + _cloudSize);
            _waterStored = (_cloudSize / tinyMax) * 100;
            Debug.Log("Water stored: " + _waterStored);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
