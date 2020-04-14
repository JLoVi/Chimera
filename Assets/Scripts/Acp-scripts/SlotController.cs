using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private TerrainNode parentNode;
    [SerializeField] private HoverInfoPopup popup;
    public GameObject inventoryUI;
    public BuildingSlot building;
    public static InventoryBuilding currentInventoryBuilding;



    private void Awake()
    {
        building = new BuildingSlot
        {
            slotMesh = this.gameObject,
            locationOnMap = transform.parent.GetComponent<NodeController>().locatonOnMap
        };
        if (GetComponentInParent<NodeController>().terrainNode != null)
        {
            parentNode = GetComponentInParent<NodeController>().terrainNode;
            building.price = parentNode.price;
            building.maintinence = parentNode.health / 3;
        }
        AcpDataHandler.buildingSlots.Add(building);
        building.id = AcpDataHandler.buildingSlots.Count;
        id = building.id;
       // Debug.Log("buildingslot created" + id);

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
        if (id == this.id)
        {
            popup.DisplayInfo();
            popup.infoText.text = "Click to see your building options on this slot";
        }
    }

    void OnSlotClick(int id)
    {
        if (id == this.id)
        {
            if (!building.containsBuilding) {
                inventoryUI.SetActive(true);
                InventoryBuilding.id = id;
            }
            else
            {
                popup.DisplayInfo();
                popup.infoText.text = "This slot already contains a building";
            }
        }

        
               
        
    }


}
