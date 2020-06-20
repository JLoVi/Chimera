using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int buildingSlotID;
    private bool exists;
    private bool fungiActive;

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

            if (exists)
            {

                buildingSlot = AcpDataHandler.instance.ReadSlotFromData(buildingSlot);
                if (buildingSlot.containsBuilding)
                {

                    GameObject meshToBuild = Instantiate(buildingSlot.building.buildingMesh, this.transform.position, Quaternion.identity);
                    meshToBuild.transform.localScale = meshToBuild.transform.localScale / 3;
                    meshToBuild.transform.parent = this.transform;

                    buildingStateController = this.GetComponentInChildren<BuildingState>();
                    fungiActive = GameManagerAcp.instance.CheckForActiveFungiUnits(buildingSlot, fungiActive);

                    if (fungiActive && buildingStateController != null)
                    {

                        buildingStateController.OnFungiAttack();
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
