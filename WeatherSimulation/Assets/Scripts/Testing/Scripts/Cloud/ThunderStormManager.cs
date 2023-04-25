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

    public WindManager WindManRef { get => _windMan; set => _windMan = value; }

    private void Awake()
    {
        _main = _lightning.main;
        _eMod = _lightning.emission;

        if (!_cloud.WindMan == null)
        {
            _windMan = _cloud.WindMan;
        }
        else
        {
            _windMan = null;
        }
    }

    private void Update()
    {
        if (_cloud.Raining)
        {
            //CheckConditions();
        }
    }

    /*private void CheckConditions()
    {
        if ()
        {
            LightingFunction();
        }
    }

    private void LightingFunction()
    {

    }*/
}
