using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AcpDataHandler : MonoBehaviour
{
    //TERRAIN
    //  public List<TerrainNode> terrainNodesOnMap = new List<TerrainNode>();
    public GameObject buildingSlotPrefab;
    public int terrainNodeCount;
    public int buildingSlotCount;

    //public List<BuildingSlot> buildingSlotsOnMap = new List<BuildingSlot>();
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
         CalculateTerrainHealth();
        gameManagerAcp.OnTerrainHealthUpdate();

        GetPurchasedTerrainNodes();
        gameManagerAcp.OnTerrainPurchased();

        GetPurchasedBuilidingTypes();
        gameManagerAcp.OnBuildingPurchased();


    }

    public bool CheckIfNodeIdExists(TerrainNode node, bool exists)
    {
        exists = false;
        for (int i = 0; i < acpData.terrainNodes.Count; i++)
        {
            if (acpData.terrainNodes[i].id == node.id)
            {
//                Debug.Log(exists);
                exists = true;
            }

        }
        return exists;
    }

    public TerrainNode ReadNodeFromData(TerrainNode node)
    {

        for (int i = 0; i < acpData.terrainNodes.Count; i++)
        {
            if (acpData.terrainNodes[i].id == node.id)
            {

                node = acpData.terrainNodes[i];

            }

        }
        return node;
    }

    public int numberOfSlotsOnNode(TerrainNode node, int slotCount)
    {
        slotCount = 0;

        for (int j = 0; j < acpData.buildingSlots.Count; j++)
        {
            if (acpData.buildingSlots[j].id == node.id)
            {
                slotCount++;
//                Debug.Log(slotCount);

            }
        }

        return slotCount;
    }

    public bool CheckIfSlotIdExists(BuildingSlot slot, bool exists)
    {
        exists = false;
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].buildingSlotID == slot.buildingSlotID)
            {
//                Debug.Log(exists);
                exists = true;
            }

        }
        return exists;
    }

    public BuildingSlot ReadSlotFromData(BuildingSlot slot)
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].buildingSlotID == slot.buildingSlotID)
            {

                slot = acpData.buildingSlots[i];

            }

        }
        return slot;
    }

    public void CalculateStats()
    {
        CalculateTerrainHealth();
        gameManagerAcp.OnTerrainHealthUpdate();
        GetPurchasedBuilidingTypes();
        gameManagerAcp.OnBuildingPurchased();
        GetMaintenanceFees();
        gameManagerAcp.OnUpdateExpenses();
        gameManagerAcp.UpdateMaintenance();

    }

      public void CalculateTerrainHealth()
      {
          double averageHealth = acpData.terrainNodes.Average(TerrainNode => TerrainNode.health);
          terrainHealth = Mathf.RoundToInt((float)averageHealth);
      }

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

            for (int i = 0; i < acpData.buildingSlots.Count; i++)
             {
                 if (acpData.buildingSlots[i].containsBuilding)
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
             }
    }

    public void GetMaintenanceFees()
    {
        maintenanceFees = 0;
          for (int i = 0; i < acpData.buildingSlots.Count; i++)
          {
              if (acpData.buildingSlots[i].containsBuilding)
              {
                  maintenanceFees += acpData.buildingSlots[i].building.maintenanceCost;
              }
          }
    }

    
}


