using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEventFunctions : MonoBehaviour
{

    public LocationStore locationStore;
    public BuildingStore buildingStore;

    public AcpData acpData;

   
    //Add resources to terrain(ACP and Fungi)
    public void AddResources()
    {
        for (int i = 0; i < locationStore.locations.Length-1; i++)
        {
            locationStore.locations[i].resources++;
        }
    }
    //Remove resources from terrain(ACP and Fungi)
    public void RemoveResources()
    {
        for (int i = 0; i < locationStore.locations.Length - 1; i++)
        {
            locationStore.locations[i].resources--;
        }
    }
    //Change the appearance of the buildings(ACP)
    //!!!!!

    //Change the impact of the buildings on humans(ACP)
    public void IncreaseResidentialImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactPeople++;
        }
    }
    public void DecreaseResidentialImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactPeople--;
        }
    }
    //Change the impact of the buildings on nature(ACP)
    public void IncreaseEnvironmentalImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactEnvironment++;
        }
    }
    public void DecreaseEnvironmentalImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactEnvironment--;
        }
    }
    //Change the impact of the buildings on economy(ACP)
    public void IncreaseFinancialImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactCapital++;
        }
    }

    public void DecreaseFinancialImpact()
    {
        for (int i = 0; i < buildingStore.buildings.Length - 1; i++)
        {
            buildingStore.buildings[i].impactCapital--;
        }
    }

    //Reduce ACP capital
    public void ReduceCapital(int value)
    {
        acpData.capital = acpData.capital - value;
    }
    //Increase ACP capital
    public void IncreaseCapital(int value)
    {
        acpData.capital = acpData.capital + value;
    }

    //Increase ACP season/turn length
    public void IncreaseSeasonLength(int value)
    {

    }
    //Decrease ACP season/turn length
    //Increase Fungi effect on ACP land and buildings
    // Decrease Fungi effect on ACP land and buildings
    //Increase ACP buildings effect on Fungi
    //Increase Fungi lifespan
    //Decrease Fungi lifespan
    //Increase fungi expansion rate(how slowly the spores appear)
    //Decrease fungi expansion rate
}
