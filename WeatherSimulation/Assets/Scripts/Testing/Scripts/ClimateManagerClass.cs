using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateManagerClass : MonoBehaviour
{
    public enum Climates 
    {
        Freezing = -15,
        Cold = -5,
        Mild = 0,
        Warm = 15,
        Hot  = 30,
        Boiling = 40,

        Average = Cold | Hot,
        Desert = Warm | Hot,
        Tropical = Warm | Hot,
        Trundra = Freezing | Mild
    }


}
