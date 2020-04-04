using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataDisplay : MonoBehaviour
{
    public FungiData fungiData;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Global Data Display:");
      //  DisplayFungiData();
    }

    public void DisplayFungiData()
    {
        if (fungiData.activeUnitLifespans != null || fungiData.activeUnitLocations != null)
        {
            foreach (LocationOnMap loc in fungiData.activeUnitLocations)
            {
                Debug.Log("Location: " + fungiData.activeUnitLocations + " Health: " + fungiData.activeUnitLifespans);
            }
        }
    }
}
