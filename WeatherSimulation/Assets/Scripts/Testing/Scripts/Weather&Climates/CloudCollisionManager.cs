using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollisionManager : MonoBehaviour
{
    [SerializeField] private static bool _hasCloud;

    public static bool HasCloud { get => _hasCloud; set => _hasCloud = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cloud")
        {
            _hasCloud = true;
            Debug.Log("New Cloud");
            other.GetComponent<CloudManager>().WeatherMan = gameObject.GetComponent<LocalWeatherManager>();
            other.GetComponent<CloudManager>().WindMan = gameObject.GetComponent<WindManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cloud")
        {
            _hasCloud = false;
            Debug.Log("New Cloud");
            other.GetComponent<CloudManager>().WeatherMan = null;
            other.GetComponent<CloudManager>().WindMan = null;
        }
    }
}
