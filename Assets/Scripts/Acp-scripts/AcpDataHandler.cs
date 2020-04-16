using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AcpDataHandler : MonoBehaviour
{
    //TERRAIN
    public List<TerrainNode> terrainNodesOnMap = new List<TerrainNode>();

    public static int terrainHealth;
    public static int terrainNodesPurchased;


    //BUILDING SLOTS
    public static List<BuildingSlot> buildingSlots = new List<BuildingSlot>();
    public static List<GameObject> buildingSlotGameObjects = new List<GameObject>();

    public static BuildingSlot selectedBuildingSlot;
    public static GameObject selectedBuildingSlotObject;

    public static GameObject buildingInventory;
    public GameObject buildingInventoryUtility;

    public static int residentialAmt;
    public static int industrialAmt;
    public static int financialAmt;

    //TURNS
    public static bool inSeason;
    public static int seasonCount;
    public static float seasonTimerValue;

    //DATA
    public AcpData acpData;
    public FungiData fungiData;
    private GameManagerAcp gameManagerAcp;
    public ColorPallette colorPallette;
    public static AcpDataHandler acpDataHandlerInstance;


    void Awake()
    {
        acpDataHandlerInstance = this;

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
        }
    }
}


