using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int buildingSlotID;
    private bool exists;

    [SerializeField] private TerrainNode parentNode;
    [SerializeField] private HoverInfoPopup popup;
    public GameObject inventoryUI;
    public BuildingSlot buildingSlot;
    //  public static InventoryBuilding currentInventoryBuilding;


    private BuildingSlot CreateBuilidingSlot()
    {
        BuildingSlot slot = new BuildingSlot
        {
            id = parentNode.id,
            location = parentNode.location,
            //price
            purchased = false
        };
        return slot;
    }
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

        if (GetComponentInParent<NodeController>().terrainNode != null)
        {
            parentNode = GetComponentInParent<NodeController>().terrainNode;

            buildingSlot = CreateBuilidingSlot();

            AcpDataHandler.instance.terrainNodeCount++;
            buildingSlot.buildingSlotID = AcpDataHandler.instance.terrainNodeCount;

            buildingSlotID = buildingSlot.buildingSlotID;

            GetComponent<SlotClickArea>().id = buildingSlotID;

            exists = AcpDataHandler.instance.CheckIfSlotIdExists(buildingSlot, exists);

            if (exists)
            {
                buildingSlot = AcpDataHandler.instance.ReadSlotFromData(buildingSlot);
                Debug.Log(buildingSlot.purchased);
            }
            else
            {
                buildingSlot.AddBuildingSlotData(AcpDataHandler.instance.acpData);
            }
            // buildingSlot.AddBuildingSlotData(AcpDataHandler.instance.acpData);

            //AcpDataHandler.instance.buildingSlotsOnMap.Add(buildingSlot);
            // buildingSlot.buildingSlotID = AcpDataHandler.instance.buildingSlotsOnMap.Count;



        }
        else
        {
            Debug.Log("can't find parent node");
        }
      


        popup = HoverInfoPopup.hoverInfoPopup;
        inventoryUI = AcpDataHandler.buildingInventory;
        inventoryUI.SetActive(false);

        GameEventsBuildingSlots.currentBuildingSlotEvent.onSlotMouseHover += OnSlotHover;
        GameEventsBuildingSlots.currentBuildingSlotEvent.onSlotMouseClick += OnSlotClick;

    }

    void OnSlotHover(int id)
    {
       
        if (id == this.buildingSlotID)
        {
            
            popup.DisplayInfo();
            popup.infoText.text = "Click to see your building options on this slot";
        }
    }

    void OnSlotClick(int id)
    {
        if (id == this.buildingSlotID)
        {
            if (!buildingSlot.containsBuilding)
            {
                inventoryUI.SetActive(true);
                //InventoryBuilding.id = id;
            }
            else
            {
                popup.DisplayInfo();
                popup.infoText.text = "This slot already contains a building";
            }
        }
    }
}
