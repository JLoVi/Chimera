using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEventFunctions : MonoBehaviour
{

    public AcpData acpData;
    public FungiData fungiData;

   
    //Add resources to terrain(ACP and Fungi)
    public void AddResources()
    {
        for (int i = 0; i < fungiData.activeUnitLocations.Count; i++)
        {
            fungiData.activeUnitLocations[i].resources++;
        }
    }
    //Remove resources from terrain(ACP and Fungi)
    public void RemoveResources()
    {
        for (int i = 0; i < fungiData.activeUnitLocations.Count; i++)
        {
            fungiData.activeUnitLocations[i].resources--;
        }
    }
    //Change the appearance of the buildings(ACP)
    //!!!!!

    public void ChangeResidentialImpact()
    {
        if (AyucGameManager.instance.currentResponseIndex == 0 || AyucGameManager.instance.currentResponseIndex == 1)
        {
            IncreaseResidentialImpact();
        }
        if (AyucGameManager.instance.currentResponseIndex == 2 || AyucGameManager.instance.currentResponseIndex == 3)
        {
            DecreaseResidentialImpact();
        }
    }
    //Change the impact of the buildings on humans(ACP)
    public void IncreaseResidentialImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding) {
                acpData.buildingSlots[i].building.impactPeople += Random.Range(10,100);
            }
        }
    }
    public void DecreaseResidentialImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                acpData.buildingSlots[i].building.impactPeople -= Random.Range(10, 100);
            }
        }
    }

    public void ChangeEnvironmentalImpact()
    {
        if (AyucGameManager.instance.currentResponseIndex == 0 || AyucGameManager.instance.currentResponseIndex == 1)
        {
            IncreaseEnvironmentalImpact();
        }
        if (AyucGameManager.instance.currentResponseIndex == 2 || AyucGameManager.instance.currentResponseIndex == 3)
        {
            DecreaseEnvironmentalImpact();
        }
    }
    //Change the impact of the buildings on nature(ACP)
    public void IncreaseEnvironmentalImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                acpData.buildingSlots[i].building.impactEnvironment += Random.Range(10, 100);
            }
        }
    }

    public void DecreaseEnvironmentalImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                acpData.buildingSlots[i].building.impactEnvironment -= Random.Range(10, 100);
            }
        }
    }

    public void ChangeFinancialImpact()
    {
        if (AyucGameManager.instance.currentResponseIndex == 0 || AyucGameManager.instance.currentResponseIndex == 1)
        {
            IncreaseFinancialImpact();
        }
        if (AyucGameManager.instance.currentResponseIndex == 2 || AyucGameManager.instance.currentResponseIndex == 3)
        {
            DecreaseFinancialImpact();
        }
    }
    //Change the impact of the buildings on economy(ACP)
    public void IncreaseFinancialImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                acpData.buildingSlots[i].building.impactPeople += Random.Range(10, 100);
            }
        }
    }

    public void DecreaseFinancialImpact()
    {
        for (int i = 0; i < acpData.buildingSlots.Count; i++)
        {
            if (acpData.buildingSlots[i].containsBuilding)
            {
                acpData.buildingSlots[i].building.impactPeople -= Random.Range(10, 100);
            }
        }
    }

    //Reduce ACP capital
    public void ReduceCapital()
    {
        acpData.capital -= acpData.capital/Random.Range(2,10);
    }
    //Increase ACP capital
    public void IncreaseCapital()
    {
        acpData.capital += acpData.capital / Random.Range(2, 10);
    }

    //Increase ACP season/turn length
    public void IncreaseSeasonLength()
    {
        acpData.seasonLength += acpData.seasonLength / Random.Range(3, 10);
    }
    //Decrease ACP season/turn length
    public void DecreaseSeasonLength()
    {
        acpData.seasonLength -= acpData.seasonLength / Random.Range(3, 10);
    }
    //Increase Fungi effect on ACP land and buildings
    public void IncreaseFungiEffect()
    {
        acpData.buildingResistanceTime += acpData.buildingResistanceTime/ Random.Range(5, 10);
    }
    // Decrease Fungi effect on ACP land and buildings
    public void DecreraseFungiEffect()
    {
        acpData.buildingResistanceTime -= acpData.buildingResistanceTime / Random.Range(5, 10);
    }
    //Increase ACP buildings effect on Fungi
    public void IncreaseFungiLifespan()
    {
        for (int i = 0; i < fungiData.activeUnitLifespans.Count; i++)
        {
            fungiData.activeUnitLifespans[i].lifespan += fungiData.activeUnitLifespans[i].lifespan / Random.Range(2, 10);
        }
    }
    public void DecreaseFungiLifespan()
    {
        for (int i = 0; i < fungiData.activeUnitLifespans.Count; i++)
        {
            fungiData.activeUnitLifespans[i].lifespan -= fungiData.activeUnitLifespans[i].lifespan / Random.Range(2, 10);
        }
    }

    public void ChangeBuildingsColor()
    {
        // Change the appearance of the buildings
    }

    public void IncreaseFungiExpansion()
    {
        fungiData.territorySpread += fungiData.territorySpread/ Random.Range(5, 10);

    }
    public void DecreaseFungiExpansion()
    {
        fungiData.territorySpread -= fungiData.territorySpread / Random.Range(5, 10);

    }
  
    
}
