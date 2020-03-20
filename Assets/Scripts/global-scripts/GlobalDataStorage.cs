using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalDataStorage : MonoBehaviour
{ 
    //ACP
    public static float capital;
    

    public static List<TerrainNode> terrainNodes = new List<TerrainNode>();
    public static List<TerrainNode> terrainUnitsPurcased = new List<TerrainNode>();

    public static List<BuildingSlot> buildingSlots = new List<BuildingSlot>();
    public static List<GameObject> buildingSlotGameObjects = new List<GameObject>();

    public static List<BuildingSlot> buildings = new List<BuildingSlot>();

    public static GameObject buildingInventory;
    public GameObject buildingInventoryUtility;

    public static bool inSeason;
    public static int seasonCount;
    public static float seasonTimerValue;

    public float SocialScoreText;
    public float EnvScoreText;
    public float EconomucScoreText;

    void Awake()
    {
        capital = Random.Range(300, 1000);

        buildingInventory = buildingInventoryUtility;

        if(buildingInventory != null) {
            Debug.Log("GLOBAL DATA STORE - Building Inventory Found");
                }

    }

    private void Start()
    {
        GameEventsGlobal.currentGlobalEvent.CapitalUpdated();
        buildingInventory.SetActive(false);
        inSeason = false;
    }

}


