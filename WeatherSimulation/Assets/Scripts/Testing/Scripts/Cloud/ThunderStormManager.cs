/*using System.Collections;
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
        if ()
        {
            LightingFunction();
        }
    }

    private void LightingFunction()
    {

    }
}*/
