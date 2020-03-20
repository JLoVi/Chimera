using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryBuilding : MonoBehaviour
{

    public static int id;
    public HoverInfoPopup popup;
    public BuildingSlot activeSlot;

    public bool highEnd;
    public BuildingType buildingType;
    public GameObject buildingMesh;

    public string pricecat;

    public GameObject InventoryPanel;
    public Text newBuildingInfo;
   

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
        popup.infoText.text = "Building Slot: " +  id + '\n' +
                  pricecat + '\n' + "Type: " + buildingType + '\n' +
                   + '\n' + '\n' + "<Click To Buy> ";
    }

    public void ExitMouseUI()
    {
      
        popup.HideInfo();
        
    }

    

    public void FindActiveSlotByID()
    {
        foreach (BuildingSlot building in GlobalDataStorage.buildingSlots)
        {
            if (building.id == id)
            {
                activeSlot = building;
               // Debug.Log("The Active Slot IS: " + activeSlot.id);
                GetBuildingProperties();
            }
        }
        
    }

    public void GetBuildingProperties()
    {
        if (!activeSlot.containsBuilding) { 
        activeSlot.buildingMesh = buildingMesh;
        activeSlot.buildingType = buildingType;
        activeSlot.highEnd = highEnd;
        }
        else
        {
            return;
        }

    }

    public void SetBuildingProperties()
    {
        if (activeSlot.buildingType == BuildingType.Financial && activeSlot.highEnd)
        {
            activeSlot.impactCapital = 3;
            activeSlot.impactPeople = 1;
            activeSlot.impactEnvironment = -2;
        }

        if (activeSlot.buildingType == BuildingType.Industrial && activeSlot.highEnd)
        {
            activeSlot.impactCapital = 2;
            activeSlot.impactPeople = 2;
            activeSlot.impactEnvironment = 2;
        }

        if (activeSlot.buildingType == BuildingType.Residential && activeSlot.highEnd)
        {
            activeSlot.impactCapital = 1;
            activeSlot.impactPeople = 3;
            activeSlot.impactEnvironment = -1;
        }

        if (activeSlot.buildingType == BuildingType.Financial && !activeSlot.highEnd)
        {
            activeSlot.impactCapital = 1;
            activeSlot.impactPeople = 1;
            activeSlot.impactEnvironment = 1;
        }

        if (activeSlot.buildingType == BuildingType.Industrial && !activeSlot.highEnd)
        {
            activeSlot.impactCapital = 1;
            activeSlot.impactPeople = 1;
            activeSlot.impactEnvironment = -3;
        }

        if (activeSlot.buildingType == BuildingType.Residential && !activeSlot.highEnd)
        {
            activeSlot.impactCapital = -3;
            activeSlot.impactPeople = 2;
            activeSlot.impactEnvironment = -2;
        }
    }

    public void Buy()
    {
        //  Debug.Log("buybuybuyb");
        if (!activeSlot.containsBuilding)
        {
            activeSlot.containsBuilding = true;
            GameObject MeshToBuild = Instantiate(buildingMesh, activeSlot.slotMesh.transform.position, Quaternion.identity);
            MeshToBuild.transform.localScale = MeshToBuild.transform.localScale / 3;
            

            if (activeSlot.highEnd) activeSlot.price = activeSlot.price * 2;
            if (!activeSlot.highEnd) activeSlot.maintinence = activeSlot.maintinence * 2 ;
           
            SetBuildingProperties();

            GlobalDataStorage.buildings.Add(activeSlot);

            GlobalDataStorage.capital = GlobalDataStorage.capital - activeSlot.price;
            GameEventsGlobal.currentGlobalEvent.CapitalUpdated();

            newBuildingInfo.gameObject.SetActive(true);

             Debug.Log("New Building: " +
                activeSlot.id + ", Capital: " + activeSlot.impactCapital + ", Environment: " + activeSlot.impactEnvironment + ", People:" + activeSlot.impactPeople +
                ", Maintenance: " + activeSlot.maintinence + ", Price: " + activeSlot.price + ", highend: " + activeSlot.highEnd + ", Type: " + activeSlot.buildingType);


            newBuildingInfo.text = "New Building: " +
                activeSlot.id + ", Capital: " + activeSlot.impactCapital + ", Environment: " + activeSlot.impactEnvironment + ", People:" + activeSlot.impactPeople +
                ", Maintenance: " + activeSlot.maintinence + ", Price: " + activeSlot.price + ", highend: " + activeSlot.highEnd + ", Type: " + activeSlot.buildingType;

            GameEventsGlobal.currentGlobalEvent.BuildingPurchased();

            
           
           
            InventoryPanel.SetActive(false);
        }

        else
        {
            return;
        }
    }

   
   

}


