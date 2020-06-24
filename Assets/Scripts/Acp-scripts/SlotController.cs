using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int buildingSlotID;
    public bool fungiActive;

    private bool exists;
    private string fungiActiveDisplay;
    private string locationDisplay;
    private string conditionDisplay;



    [SerializeField] private TerrainNode parentNode;
    [SerializeField] private HoverInfoPopup popup;
    [SerializeField] private BuildingState buildingStateController;
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
            purchased = false,
            slotCondition = Condition.Stable
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

            AcpDataHandler.instance.buildingSlotCount++;
            buildingSlot.buildingSlotID = AcpDataHandler.instance.buildingSlotCount;

            buildingSlotID = buildingSlot.buildingSlotID;

            GetComponent<SlotClickArea>().id = buildingSlotID;

            exists = AcpDataHandler.instance.CheckIfSlotIdExists(buildingSlot, exists);
            fungiActive = GameManagerAcp.instance.CheckForActiveFungiUnits(buildingSlot, fungiActive);

            if (exists)
            {

                buildingSlot = AcpDataHandler.instance.ReadSlotFromData(buildingSlot);
                if (buildingSlot.containsBuilding)
                {

                    GameObject meshToBuild = Instantiate(buildingSlot.building.buildingMesh, this.transform.position, Quaternion.identity);
                    meshToBuild.transform.localScale = meshToBuild.transform.localScale / 3;
                    meshToBuild.transform.parent = this.transform;

                    buildingStateController = this.GetComponentInChildren<BuildingState>();
                    buildingStateController.parentSlot = this;

                    if (fungiActive && buildingStateController != null && buildingSlot.building.buildingType != BuildingType.Sanitation)
                    {

                        buildingStateController.OnFungiAttack();
                        buildingSlot.slotCondition = Condition.Damaged;
                    }

                    if (buildingSlot.building.buildingType == BuildingType.Sanitation)
                    {
                        GameEventsBuildingSlots.currentBuildingSlotEvent.RecoverFromAttack(buildingSlot.location, fungiActive);

                    }
                }
            }

            else
            {
                buildingSlot.AddBuildingSlotData(AcpDataHandler.instance.acpData);
            }
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

            //Debug.Log(fungiActive);
            fungiActiveDisplay = fungiActive ? "Fungi are active in this area" : " Fungi are absent from this area";

            if (buildingSlot.location != null)
            {
                locationDisplay = buildingSlot.location.Location.ToString();
            }
            else
            {
                locationDisplay = "none";
            }

            if (buildingSlot.containsBuilding)
            {
                popup.infoText.text =
              fungiActiveDisplay.ToString()
              + '\n' + '\n' + "Parent Node ID: " + buildingSlot.id.ToString()
              + '\n' + '\n' + "Building Slot ID: " + buildingSlot.buildingSlotID.ToString()
              + '\n' + '\n' + "Building Type: " + buildingSlot.building.buildingType.ToString()
              + '\n' + '\n' + "Location on map: " + locationDisplay
              + '\n' + '\n' + "Building Condition: " + conditionDisplay;
                conditionDisplay = buildingSlot.slotCondition.ToString();
            }

            else if (!buildingSlot.containsBuilding)
                popup.infoText.text =
                   fungiActiveDisplay.ToString() + '\n' + '\n' + "Click to see your building options on this slot"
                    + '\n' + '\n' + "Location on map: " + locationDisplay;
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

    public void RemoveSlotFromDatabase()
    {
        AcpDataHandler.instance.acpData.buildingSlots.Remove(buildingSlot);
        AcpDataHandler.instance.CalculateStats();
        this.gameObject.SetActive(false);

    }
}
