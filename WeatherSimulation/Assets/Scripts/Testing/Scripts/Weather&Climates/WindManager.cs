using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    //[SerializeField] private ClimateManagerClass _climateMan;

    [Header("Wind Variables")]
    [SerializeField] private float _windSpeed;
    [SerializeField] private float _speedMin;
    [SerializeField] private float _speedMax;

    [SerializeField] private LocalWeatherManager _weather;

    public float Speed { get => _windSpeed; set => _windSpeed = value; }
    public float WindMin { get => _speedMin; set => _speedMin = value; }
    public float WindMax { get => _speedMax; set => _speedMax = value; }

    // Update is called once per frame
    void Update()
    {
        
    }


}
