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
    [SerializeField] private GameEvent purchaseBuilding;
    [SerializeField] public GameEvent updateExpenses;

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

        GameObject meshToBuild = Instantiate(building.buildingMesh, AcpDataHandler.selectedBuildingSlotObject.transform.position, Quaternion.identity);
        meshToBuild.transform.localScale = meshToBuild.transform.localScale / 3;

        UpdateSelectedBuilding();
        DisplayPurchasedBuildngInfo();
       
        InventoryPanel.SetActive(false);

        meshToBuild.transform.parent = AcpDataHandler.acpRuntimeAssetParent.transform;
    }

    public void UpdateSelectedBuilding()
    {
        building.maintenanceCost = AcpDataHandler.selectedBuildingSlot.health / 2;

        AcpDataHandler.selectedBuildingSlot.purchased = true;
        AcpDataHandler.selectedBuildingSlot.containsBuilding = true;
        AcpDataHandler.selectedBuildingSlot.building = building;

        acpData.capital -= (AcpDataHandler.selectedBuildingSlot.price + building.constructitonCost);
        acpData.socialScore += building.impactPeople;
        acpData.environmentScore += building.impactEnvironment;
        acpData.economicGrowth += building.impactCapital;

        updateCapital.Raise();
        AcpDataHandler.selectedBuildingSlot.ModifyBuildingSlotData(acpData, AcpDataHandler.selectedBuildingSlot);
        purchaseBuilding.Raise();
        AcpDataHandler.expenses += AcpDataHandler.selectedBuildingSlot.price + building.constructitonCost;
        updateExpenses.Raise();
    }

    public void DisplayPurchasedBuildngInfo()
    {
        newBuildingInfo.gameObject.SetActive(true);
        newBuildingInfo.color = new Color(newBuildingInfo.color.r, newBuildingInfo.color.g, newBuildingInfo.color.b, 1);
        newBuildingInfo.text = "New Building: " + building.buildingType + '\n' +
        "Land Costs: " + AcpDataHandler.selectedBuildingSlot.price + '\n' + "Construction Cost: " + building.constructitonCost + '\n' +
        "Seasonal Maintenance Cost: " + building.maintenanceCost;
        newBuildingInfo.gameObject.GetComponent<FadeOutText>().FadeOut();
    }
}


