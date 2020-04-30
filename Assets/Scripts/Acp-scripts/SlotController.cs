using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int buildingSlotID;
    [SerializeField] private TerrainNode parentNode;
    [SerializeField] private HoverInfoPopup popup;
    public GameObject inventoryUI;
    public BuildingSlot buildingSlot;
    //  public static InventoryBuilding currentInventoryBuilding;




    private void Awake()
    {
        buildingSlot = new BuildingSlot(false);

        if (GetComponentInParent<NodeController>().terrainNode != null)
        {
            parentNode = GetComponentInParent<NodeController>().terrainNode;
            buildingSlot.price = parentNode.price;
            buildingSlot.id = parentNode.id;
            buildingSlot.location = parentNode.location;
            buildingSlot.health = parentNode.health;


        }
        AcpDataHandler.buildingSlots.Add(buildingSlot);
        buildingSlot.AddBuildingSlotData(GetComponentInParent<NodeController>().acpData);
        buildingSlot.buildingSlotID = AcpDataHandler.buildingSlots.Count;
        buildingSlotID = buildingSlot.buildingSlotID;
       // transform.parent = AcpDataHandler.acpRuntimeAssetParent.transform;


    }

    // Start is called before the first frame update
    void Start()
    {
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
