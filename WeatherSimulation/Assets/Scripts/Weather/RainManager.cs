using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    //NOTE(Tane) These arrays are responsible for the cloud sizes and catagories. These can be edtied at the users discrection
    
    public enum CloudProperties { Tiny, Small, Medium, Large, Huge }
    public CloudProperties _cloudProperties;

    //NOTE(Tane) variables for min & max size per catagory including thier unique down pour threshold
    [SerializeField] private int _cloudSize;
    [SerializeField] private int tinyMin,   tinyMax;
    [SerializeField] private int smallMin,  smallMax;
    [SerializeField] private int mediumMin, mediumMax;
    [SerializeField] private int largeMin,  largeMax;
    [SerializeField] private int hugeMin,   hugeMax;

    [SerializeField] private float _downpourThreshTiny;
    [SerializeField] private float _downpourThreshSmall;
    [SerializeField] private float _downpourThreshMedium;
    [SerializeField] private float _downpourThreshLarge;
    [SerializeField] private float _downpourThreshHuge;

    //NOTE(Tane) Variables that are set and effected by the clouds size & catagory
    [SerializeField] private float _waterStored;
    [SerializeField] private int _duration;
    [SerializeField] private int _intensity;
    [SerializeField] private int _timeTillRain;
    [SerializeField] private bool _isRaining;

    private float waterMin, WaterMax;
    private int durationMin, durationMax;
    private int intenseMin;
    private int timeTillMin, timeTillMax;

    private void Awake()
    {
        tinyMin   = 1;   
        tinyMax   = 2;
        smallMin  = 3; 
        smallMax  = 4;
        mediumMin = 5;
        mediumMax = 6;
        largeMin  = 7;
        largeMax  = 8;
        hugeMin   = 9;
        hugeMax   = 10;
    }

    /*
    private void OnValidate()
    {
        _isRainging = false;

        //NOTE: Tiny cclouds
        if (tinyMin != 0)
        {
            if (tinyMin < 0)
            {
                tinyMin = 0;
                Debug.Log("The cloud size values cannot be negative");
            }

            else if (tinyMin >= tinyMax)
            {
                tinyMin = tinyMax - 1;
                Debug.Log("A cloud catagories Min size value cannot be greater than it's Max size value.");

            }
        }
        
        if (tinyMax != 0)
        {
            if (tinyMax >= smallMin)
            {
                tinyMax = smallMin - 1;
                Debug.Log("The Max size value cannot be equal to or greater than the Min size value of the catagory above");    
            }
            else if (tinyMax <= tinyMin)
            {
                tinyMax = tinyMin + 1;
            }
        }

        //NOTE: Small clouds
        if (smallMin != 0)
        {
            if (smallMin < tinyMax)
            {
                smallMin = tinyMax + 1;
                Debug.Log("A cloud catagories Min size value cannot be less than the previious catagories' Max size value.");
            }
            else if (smallMin >= smallMax)
            {
                smallMin = smallMax - 1;
                Debug.Log("A cloud catagories Min size value cannot be greater than it's Max size value.");
            }
        }

        if (smallMax != 0)
        {
            if (smallMax >= mediumMin)
            {
                smallMax = mediumMin - 1;
                Debug.Log("The Max size value cannot be equal to or greater than the Min size value of the catagory above");
            }
            else if (smallMax <= smallMin)
            {
                smallMax = smallMin + 1;
            }
        }

        //NOTE: Medium clouds
        if (mediumMin != 0)
        {
            if (mediumMin < smallMax)
            {
                mediumMin = smallMax + 1;
                Debug.Log("A cloud catagories Min size value cannot be less than the previious catagories' Max size value.");
            }
            else if (mediumMin >= mediumMax)
            {
                mediumMin = mediumMax - 1;
                Debug.Log("A cloud catagories Min size value cannot be greater than it's Max size value.");
            }
        }

        if (mediumMax != 0)
        { 
            if (mediumMax >= largeMin)
            {
                mediumMax = largeMin - 1;
                Debug.Log("The Max size value cannot be equal to or greater than the Min size value of the catagory above");
            }
            else if (mediumMax <= mediumMin)
            {
                mediumMax = mediumMin + 1;
            }
        }

        //NOTE: Large clouds
        if (largeMin != 0)
        {
            if (largeMin < mediumMax)
            {
                largeMin = mediumMax + 1;
                Debug.Log("A cloud catagories Min size value cannot be less than the previious catagories' Max size value.");
            }
            else if (largeMin >= largeMax)
            {
                largeMin = largeMax - 1;
                Debug.Log("A cloud catagories Min size value cannot be greater than it's Max size value.");
            }
        }

        if (largeMax != 0)
        {
            if (largeMax >= hugeMin)
            {
                largeMax = hugeMin - 1;
                 Debug.Log("The Max size value cannot be equal to or greater than the Min size value of the catagory above");
            }
            else if (largeMax <= largeMin)
            {
                largeMax = largeMin + 1;
            }
        }

        //NOTE: Huge clouds
        if (hugeMin != 0)
        {
            if (hugeMin < largeMax)
            {
                hugeMin = largeMax + 1;
                Debug.Log("A cloud catagories Min size value cannot be less than the previious catagories' Max size value.");
            }
            else if (hugeMin >= hugeMax)
            {
                hugeMin = hugeMax - 1;
                Debug.Log("A cloud catagories Min size value cannot be greater than it's Max size value.");
            }
        }

        if (hugeMax != 0)
        {
            if (hugeMax > 100)
            {
                hugeMax = 100;
                Debug.Log("The Max size value of a Huge cannot be greater than 0");
            }
        }
    }*/

    void CloudSizeManager()
    {
        //_waterStored;
    }

    void CloudRainingManager()
    {
        //_waterStored

        //_intensity;
        //_duration;
        //_isRaining;
    }

}

