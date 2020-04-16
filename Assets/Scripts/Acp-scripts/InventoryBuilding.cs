using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryBuilding : MonoBehaviour
{

    public int inventoryID;
    public HoverInfoPopup popup;
    public Building building;

    public GameObject InventoryPanel;
    public Text newBuildingInfo;

    [SerializeField] private GameEvent updateCapital;
    [SerializeField] private AcpData acpData;

    private void Start()
    {
        popup = HoverInfoPopup.hoverInfoPopup;
        newBuildingInfo.gameObject.SetActive(false);
    }

    public void MouseClickUI()
    {
        popup.HideInfo();
        Buy();
    }

    public void MouseOnUI()
    {
        popup.DisplayInfo();

        string pricecat = building.highEnd ? "High End " : "Cheap ";
        popup.infoText.text = "Building : " + building.buildingType + '\n' +
                    pricecat + '\n' + "Costs: " + '\n' +
                    "Land: " + AcpDataHandler.selectedBuildingSlot.price + "Construction: " + building.constructitonCost + '\n' +
                    "Seasonal Maintenance Cost: " + building.maintenanceCost +
                    '\n' + '\n' + "<Click To Buy> ";
    }

    public void ExitMouseUI()
    {
        popup.HideInfo();
    }

    public void Buy()
    {

        GameObject MeshToBuild = Instantiate(building.buildingMesh, AcpDataHandler.selectedBuildingSlotObject.transform.position, Quaternion.identity);
        MeshToBuild.transform.localScale = MeshToBuild.transform.localScale / 3;

        AcpDataHandler.selectedBuildingSlot.purchased = true;
        AcpDataHandler.selectedBuildingSlot.containsBuilding = true;
        AcpDataHandler.selectedBuildingSlot.building = building;

        acpData.capital = acpData.capital - (AcpDataHandler.selectedBuildingSlot.price + building.constructitonCost);
        updateCapital.Raise();
        AcpDataHandler.selectedBuildingSlot.ModifyBuildingSlotData(acpData, AcpDataHandler.selectedBuildingSlot);

        newBuildingInfo.gameObject.SetActive(true);
        newBuildingInfo.color = new Color(newBuildingInfo.color.r, newBuildingInfo.color.g, newBuildingInfo.color.b, 1);
        newBuildingInfo.text = "New Building: " + building.buildingType + '\n' +
        "Land Costs: " + AcpDataHandler.selectedBuildingSlot.price + "Construction Cost: " + building.constructitonCost + '\n' +
        "Seasonal Maintenance Cost: " + building.maintenanceCost;
        InventoryPanel.SetActive(false);
    }
}


