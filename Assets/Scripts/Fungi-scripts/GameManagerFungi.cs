using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManagerFungi : MonoBehaviour
{
    public FungiData fungiData;
    public AcpData acpData;
    public RockData rockData;

    public List<GameObject> fungiUnits;

    public static LocationOnMap activeLocation;
    public static FungiUnitLifespan activeLifespan;

    public static LocationOnMap deadLocation;
    public static FungiUnitLifespan deadLifespan;

    public Text territoryText;
    //public static float territoryPercentage;


    public static GameObject fungiRuntimeAssetParent;
    [SerializeField] private GameEvent OnUnitActivated;

    public static GameManagerFungi instance;

    void OnEnable()
    {
        ActivateFungiUnit.OnDeactivated += RemoveFungiData;
    }

    void OnDisable()
    {
        ActivateFungiUnit.OnDeactivated -= RemoveFungiData;
    }

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        fungiRuntimeAssetParent = GameObject.Find("FUNGI-runtime-assets");

        if (fungiRuntimeAssetParent != null)
        {
            Debug.Log(fungiRuntimeAssetParent.name + " ++ FUNGI runtime parent found!");
            rockData.fungiRuntimeAssets = fungiRuntimeAssetParent;
        }
        else
        {
            Debug.LogError(" FUNGI runtime parent NOT FOUND!");
        }

        territoryText = GameObject.Find("textterritory").GetComponent<Text>();
        territoryText.text = "territory occupied: " + fungiData.territorySpread + "%";
        if (fungiData.territorySpread > 100)
        {
            //territoryText.text = "territory occupied: " + "100" + "%";
            territoryText.text = "victory condition fulfilled";
        }
        // OnUnitActivated.Raise();
        if (fungiData.territorySpread < 0)
        {
            territoryText.text = "territory occupied: " + "0" + "%";

        }
    }

    public bool CheckIfUnitExists(LocationOnMap location, bool exists)
    {
        exists = false;
        for (int i = 0; i < fungiData.activeUnitLocations.Count; i++)
        {
            if (fungiData.activeUnitLocations[i] == location)
            {
                exists = true;
                //  Debug.Log(exists);
            }

        }
        return exists;
    }

    public bool CheckIfSanitationPresent(LocationOnMap location, bool exists)
    {
        exists = false;
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].location == location && acpData.buildingSlots[i].containsBuilding)
            {
                if (acpData.buildingSlots[i].building.buildingType == BuildingType.Sanitation)
                {
                    exists = true;
                    Debug.Log(exists);
                }
            }
        }
        return exists;
    }

    public void IncreaseTerritory(float min, float max)
    {
        if (fungiData.territorySpread < 100)
        {

            fungiData.territorySpread += UnityEngine.Random.Range(min, max);

            float territoryRounded = (float)Math.Round(fungiData.territorySpread, 1);
            territoryText.text = "territory occupied: " + territoryRounded + "%";
            fungiData.territorySpread = territoryRounded;
            if (territoryRounded > 100)
            {
                territoryText.text = "territory occupied: " + "100" + "%";
                territoryText.text = "victory condition fulfilled";
            }
            if (territoryRounded < 0)
            {
                territoryText.text = "territory occupied: " + "0" + "%";

            }
        }
    }
    public void DecreaseTerritory(float min, float max)
    {
        if (fungiData.territorySpread > 0)
        {
            fungiData.territorySpread -= UnityEngine.Random.Range(min, max);

            float territoryRounded = (float)Math.Round(fungiData.territorySpread, 1);
            territoryText.text = "territory occupied: " + territoryRounded + "%";
            fungiData.territorySpread = territoryRounded;
            if (territoryRounded > 100)
            {
                territoryText.text = "territory occupied: " + "100" + "%";
                territoryText.text = "victory condition fulfilled";
            }

            if (territoryRounded < 0)
            {
                territoryText.text = "territory occupied: " + "0" + "%";
               
            }
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

        public void ShowFungiData()
        {
            // Debug.Log("fungi unit saved in data");
            //  Debug.Log("location: " + fungiData.activeUnitLocations + " lifespan: " + fungiData.activeUnitLifespans);
        }
    }