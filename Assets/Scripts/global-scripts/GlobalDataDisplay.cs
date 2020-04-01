using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataDisplay : MonoBehaviour
{
    public FungiData fungiData;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Global Data Display:" );

        foreach (LocationOnMap loc in fungiData.activeUnitLocations)
        {
            Debug.Log("LLLL");

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
