//AUTHOR: Tane Cotterell-East (Roonstar96)

//SUMMARY: This script is repsonsibel for simulating lighting only. It takes in the rains intensity, current humidity and wind 
// and uses them to calculate how often lightnigh will strike during a storm.
// NOTE: This script has not been thoroughly tested as there were issues with _lightning particle system playing during rain
// regardless if the conditions have been met



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormManager : MonoBehaviour
{
    [Header("Storm Variables")]
    [SerializeField] private ParticleSystem _lightning;
    private ParticleSystem.MainModule _main;
    private ParticleSystem.EmissionModule _eMod;

    [Header("Manager references")]
    [SerializeField] private CloudManager _cloud;
    [SerializeField] private WindManager _windMan;
    [SerializeField] private LocalWeatherManager _weatherMan;

    public WindManager WindManRef { get => _windMan; set => _windMan = value; }
    public LocalWeatherManager LocalWeatherRef { get => _weatherMan; set => _weatherMan = value; }

    private void Awake()
    {
        _main = _lightning.main;
        _eMod = _lightning.emission;
    }

    private void Update()
    {
        if (_cloud.Raining)
        {
            CheckConditions();
        }
    }

    private void CheckConditions()
    {
        if (_weatherMan.Humidity >= 65)
        {
            LightingFunction();
        }
        else
        {
            return;
        }
    }

    private void LightingFunction()
    {
        if (_windMan.Speed > 25 && _cloud.Intensity > 1.85)
        {
            float LightningStrike = (_weatherMan.Humidity / _windMan.Speed) * _cloud.Intensity ;
            _eMod.rateOverTime = LightningStrike;
            _lightning.Play();
        }
        else
        {
            return;
        }
    }
}
