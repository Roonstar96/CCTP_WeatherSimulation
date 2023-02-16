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
            other.GetComponent<CloudManager>().weather = gameObject.GetComponent<LocalWeatherManager>();
            other.GetComponent<CloudManager>().wind = gameObject.GetComponent<WindManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cloud")
        {
            Debug.Log("New Cloud");
            other.GetComponent<CloudManager>().weather = null;
            other.GetComponent<CloudManager>().wind = null;
        }
    }
}
