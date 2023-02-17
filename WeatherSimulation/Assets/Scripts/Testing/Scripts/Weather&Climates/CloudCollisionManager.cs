using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cloud")
        {
            Debug.Log("New Cloud");
            other.GetComponent<CloudManager>().WeatherMan = gameObject.GetComponent<LocalWeatherManager>();
            other.GetComponent<CloudManager>().WindMan = gameObject.GetComponent<WindManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cloud")
        {
            Debug.Log("New Cloud");
            other.GetComponent<CloudManager>().WeatherMan = null;
            other.GetComponent<CloudManager>().WindMan = null;
        }
    }
}
