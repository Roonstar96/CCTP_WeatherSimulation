//AUTHOR: Tane Cotterell-East (Roonstar96)

//SUMMARY: This script is responsible for assignining & setting variables in the cloud object
//when it enters/leaves the Local climates volume, allow the cloud to absorb water or start
//raining/snowing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollisionManager : MonoBehaviour
{
    [SerializeField] private bool _hasCloud;
    [SerializeField] private LocalWeatherManager _localWeatherMan;
    [SerializeField] private WindManager _windMan;
    
    public bool HasCloud { get => _hasCloud; set => _hasCloud = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cloud")
        {
            _hasCloud = true;
            Debug.Log("New Cloud");
            var cloud = other.GetComponent<CloudManager>();
            cloud.WeatherMan = _localWeatherMan;
            cloud.WindMan = _windMan;
            cloud.CurrentWind = _windMan.Speed;
            cloud.Storing = true;
            _localWeatherMan.CloudMan = other.gameObject.GetComponent<CloudManager>();
            _localWeatherMan.SubscribeToEvents();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cloud")
        {
            _hasCloud = false;
            Debug.Log("Cloud is gone");
            var cloud = other.GetComponent<CloudManager>();
            cloud.WeatherMan = null;
            cloud.WindMan = null;
            cloud.Storing = false;
            _localWeatherMan.CloudMan = null;
            _localWeatherMan.SubscribeToEvents();
        }
    }
}
