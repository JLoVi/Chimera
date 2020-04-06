using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManagerFungi : MonoBehaviour
{

    public FungiData fungiData;

    public static LocationOnMap activeLocation;
    public static FungiUnitLifespan activeLifespan;

    public static LocationOnMap deadLocation;
    public static FungiUnitLifespan deadLifespan;

    public Text territoryText;
    public static float territoryPercentage;

    void OnEnable()
    {
        ActivateFungiUnit.OnDeactivated += RemoveFungiData;
    }

    void OnDisable()
    {
        ActivateFungiUnit.OnDeactivated -= RemoveFungiData;
    }

    public void Start()
    {
        territoryText = GameObject.Find("textterritory").GetComponent<Text>();
        territoryText.text = "territory occupied: " + territoryPercentage + "%";

    }

    public void ShowFungiData()
    {
        // Debug.Log("fungi unit saved in data");
        //  Debug.Log("location: " + fungiData.activeUnitLocations + " lifespan: " + fungiData.activeUnitLifespans);
    }

    public void IncreaseTerritory()
    {
        if (territoryPercentage < 100)
        {
            territoryPercentage += UnityEngine.Random.Range(0.1f, 0.3f);
            float territoryRounded = (float)Math.Round(territoryPercentage, 1);
            territoryText.text = "territory occupied: " + territoryRounded + "%";
        }
    }

    public void RemoveFungiData()
    {
        for (int i = 0; i < fungiData.activeUnitLocations.Count; i++)
        {
            if (fungiData.activeUnitLocations[i].name == deadLocation.name)
            {
                fungiData.activeUnitLocations.RemoveAt(i);
            }
        }
        for (int i = 0; i < fungiData.activeUnitLifespans.Count; i++)
        {
            if (fungiData.activeUnitLifespans[i].name == deadLifespan.name)
            {
                fungiData.activeUnitLifespans.RemoveAt(i);
            }
        }
    }
}