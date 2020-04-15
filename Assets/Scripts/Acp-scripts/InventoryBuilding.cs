using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryBuilding : MonoBehaviour
{

    public int inventoryID;
    public HoverInfoPopup popup;

    public BuildingSlot activeSlot;

    public bool highEnd;
    public BuildingType buildingType;
    public GameObject buildingMesh;

    public string pricecat;

    public GameObject InventoryPanel;
    public Text newBuildingInfo;

    [SerializeField] private GameEvent updateCapital;
    [SerializeField] private AcpData acpData;



    private void Start()
    {
        popup = HoverInfoPopup.hoverInfoPopup;

        pricecat = highEnd ? "High End " : "Cheap ";

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
        popup.infoText.text = "Building Slot: " + inventoryID + '\n' +
                  pricecat + '\n' + "Type: " + buildingType + '\n' +
                   +'\n' + '\n' + "<Click To Buy> ";
    }

    public void ExitMouseUI()
    {

        popup.HideInfo();

    }

    public void Buy()
    {
     
            activeSlot.containsBuilding = true;
            GameObject MeshToBuild = Instantiate(buildingMesh, SlotClickArea.selectedBuildingSlotObject.transform.position, Quaternion.identity);
            MeshToBuild.transform.localScale = MeshToBuild.transform.localScale / 3;


            acpData.capital = acpData.capital - activeSlot.price;
            updateCapital.Raise();

            newBuildingInfo.gameObject.SetActive(true);

    /*        Debug.Log("New Building: " +
               activeSlot.id + ", Capital: " + activeSlot.impactCapital + ", Environment: " + activeSlot.impactEnvironment + ", People:" + activeSlot.impactPeople +
               ", Maintenance: " + activeSlot.maintinence + ", Price: " + activeSlot.price + ", highend: " + activeSlot.highEnd + ", Type: " + activeSlot.buildingType);


            newBuildingInfo.text = "New Building: " +
                activeSlot.id + ", Capital: " + activeSlot.impactCapital + ", Environment: " + activeSlot.impactEnvironment + ", People:" + activeSlot.impactPeople +
                ", Maintenance: " + activeSlot.maintinence + ", Price: " + activeSlot.price + ", highend: " + activeSlot.highEnd + ", Type: " + activeSlot.buildingType;

            GameEventsGlobal.currentGlobalEvent.BuildingPurchased();*/

            InventoryPanel.SetActive(false);
       
    }




}


