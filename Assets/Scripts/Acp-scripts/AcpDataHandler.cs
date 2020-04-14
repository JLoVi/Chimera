using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcpDataHandler : MonoBehaviour
{
    public List<TerrainNode> terrainNodesOnMap = new List<TerrainNode>();

    public static List<BuildingSlot> buildingSlots = new List<BuildingSlot>();
    public static List<GameObject> buildingSlotGameObjects = new List<GameObject>();


    public static GameObject buildingInventory;
    public GameObject buildingInventoryUtility;

    public static bool inSeason;
    public static int seasonCount;
    public static float seasonTimerValue;

    public float SocialScoreText;
    public float EnvScoreText;
    public float EconomucScoreText;

    public FungiData fungiData;
    public ColorPallette colorPallette;

    public static AcpDataHandler acpDataHandlerInstance;

    void Awake()
    {
        acpDataHandlerInstance = this;

        buildingInventory = buildingInventoryUtility;

        if(buildingInventory != null) {
            Debug.Log("ACP data utility - Building Inventory Found");
                }

    }

    private void Start()
    {
        buildingInventory.SetActive(false);
        inSeason = false;

    }

}


