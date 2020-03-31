using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fungi Data", menuName = " Fungi Data", order = 51)]

public class FungiData : ScriptableObject
{
    [SerializeField]
    private Dictionary<LocationOnMap, FungiUnitLifespan> activeFungiUnits = new Dictionary<LocationOnMap, FungiUnitLifespan>();


    public Dictionary<LocationOnMap, FungiUnitLifespan> ActiveFungiUnits
    {
        get
        {
            return activeFungiUnits;
        }
    }
}
