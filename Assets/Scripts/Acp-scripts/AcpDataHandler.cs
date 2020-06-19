﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AcpDataHandler : MonoBehaviour
{
    //TERRAIN
    //  public List<TerrainNode> terrainNodesOnMap = new List<TerrainNode>();
    public int terrainNodeCount;

    public List<BuildingSlot> buildingSlotsOnMap = new List<BuildingSlot>();
    public List<GameObject> buildingSlotGameObjects = new List<GameObject>();

    public static int terrainHealth;
    public static int terrainNodesPurchased;

    public static BuildingSlot selectedBuildingSlot;
    public static GameObject selectedBuildingSlotObject;

    public static GameObject buildingInventory;
    public GameObject buildingInventoryUtility;

    public static int residentialAmt;
    public static int industrialAmt;
    public static int financialAmt;

    //FINANCIAL DATA:
    public static int expenses;
    public static int maintenanceFees;
    public static int revenues;

    //TURNS
    public static bool inSeason;
    public static int seasonCount;
    public static float seasonTimerValue;

    //DATA
    public static GameObject acpRuntimeAssetParent;
    public AcpData acpData;
    public FungiData fungiData;
    public RockData rockData;
    private GameManagerAcp gameManagerAcp;
    public ColorPallette colorPallette;
    public static AcpDataHandler instance;


    void Awake()
    {
        instance = this;

        buildingInventory = buildingInventoryUtility;

        if (buildingInventory != null)
        {
            Debug.Log("ACP data utility - Building Inventory Found");
        }

        if (GetComponent<GameManagerAcp>() != null)
        {
            gameManagerAcp = GetComponent<GameManagerAcp>();
        }

      
    }

    private void Start()
    {
        acpRuntimeAssetParent = GameObject.Find("ACP-runtime-assets");
        if (acpRuntimeAssetParent != null)
        {
            Debug.Log(acpRuntimeAssetParent.name + " ++ ACP runtime parent found!");
            rockData.acpRuntimeAssets = acpRuntimeAssetParent;
        }
        else
        {
            Debug.LogError(" ACP runtime parent NOT FOUND!");
        }

        buildingInventory.SetActive(false);
        inSeason = false;
        //terrainHealth = terrainNodesOnMap.Sum(TerrainNode => TerrainNode.health);
       // CalculateTerrainHealth();
        gameManagerAcp.OnTerrainHealthUpdate();

        GetPurchasedTerrainNodes();
        gameManagerAcp.OnTerrainPurchased();

        GetPurchasedBuilidingTypes();
        gameManagerAcp.OnBuildingPurchased();


    }



  /*  public void CalculateTerrainHealth()
    {
        double averageHealth = acpData.terrainNodes.Average(TerrainNode => TerrainNode.health);
        terrainHealth = Mathf.RoundToInt((float)averageHealth);
    }*/

    public void GetPurchasedTerrainNodes()
    {
        terrainNodesPurchased = 0;
        for (int i = 0; i < acpData.terrainNodes.Count; i++)
        {
            if (acpData.terrainNodes[i].purchased)
            {
                terrainNodesPurchased++;
            }
        }
    }

    public void GetPurchasedBuilidingTypes()
    {
        residentialAmt = 0;
        industrialAmt = 0;
        financialAmt = 0;

   /*     for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (buildingSlots[i].containsBuilding)
            {
                if (acpData.buildingSlots[i].building.buildingType == BuildingType.Residential)
                {
                    residentialAmt++;
                }
                if (acpData.buildingSlots[i].building.buildingType == BuildingType.Industrial)
                {
                    industrialAmt++;
                }
                if (acpData.buildingSlots[i].building.buildingType == BuildingType.Financial)
                {
                    financialAmt++;
                }
            }
        }*/
    }

    public void GetMaintenanceFees()
    {
        maintenanceFees = 0;
      /*  for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                maintenanceFees += acpData.buildingSlots[i].building.maintenanceCost;
            }
        }*/
    }

}


