using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFungi : MonoBehaviour
{

    public FungiData fungiData;

    public void Start()
    {
        
    }

    public void ShowFungiData()
    {
        foreach(KeyValuePair<LocationOnMap, FungiUnitLifespan> fungiUnitValues in fungiData.ActiveFungiUnits)
        {
            Debug.Log("position " + fungiUnitValues.Key + " Health" + fungiUnitValues.Value.health + " Lifespan " + fungiUnitValues.Value.lifespan);
        }
    }
}
