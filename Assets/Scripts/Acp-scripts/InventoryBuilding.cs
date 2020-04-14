using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryBuilding : MonoBehaviour
{

    public int inventoryID;
    public HoverInfoPopup popup;

    public BuildingSlot activeSlot;
    public Transform activeSlotTransform;

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

        FindActiveSlotByID();

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
        FindActiveSlotByID();


        popup.DisplayInfo();
        popup.infoText.text = "Building Slot: " + inventoryID + '\n' +
                  pricecat + '\n' + "Type: " + buildingType + '\n' +
                   +'\n' + '\n' + "<Click To Buy> ";
    }

    public void ExitMouseUI()
    {

        popup.HideInfo();

    }



    public void FindActiveSlotByID()
    {
        foreach (BuildingSlot buildingSlot in AcpDataHandler.buildingSlots)
        {
            if (buildingSlot.buildingSlotID == inventoryID)
            {
                activeSlot = buildingSlot;
                Debug.Log("The Active Slot IS: " + activeSlot.id);
            }
        }
        for (int i = 0; i < AcpDataHandler.buildingSlots.Count; i++)
        {
            if (AcpDataHandler.buildingSlots[i].buildingSlotID == inventoryID)
            {
                activeSlot = AcpDataHandler.buildingSlots[i];
                activeSlotTransform = AcpDataHandler.buildingSlotGameObjects[i].transform;
                
            }
        }
    }

    public void Buy()
    {
     
            activeSlot.containsBuilding = true;
            GameObject MeshToBuild = Instantiate(buildingMesh, activeSlotTransform.position, Quaternion.identity);
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


