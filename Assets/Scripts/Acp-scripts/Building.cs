using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : TerrainNode
{
    public int maintenance;
    public bool highEnd;
    public BuildingType buildingType;
    public GameObject buildingMesh;
    public int impactEnvironment;
    public int impactPeople;
    public int impactCapital;

    public void SetBuildingProperties()
    {
        if (buildingType == BuildingType.Financial && highEnd)
        {
            impactCapital = 3;
           impactPeople = 1;
            impactEnvironment = -2;
        }

        if (buildingType == BuildingType.Industrial && highEnd)
        {
            impactCapital = 2;
            impactPeople = 2;
            impactEnvironment = 2;
        }

        if (buildingType == BuildingType.Residential && highEnd)
        {
            impactCapital = 1;
            impactPeople = 3;
            impactEnvironment = -1;
        }

        if (buildingType == BuildingType.Financial && !highEnd)
        {
            impactCapital = 1;
            impactPeople = 1;
            impactEnvironment = 1;
        }

        if (buildingType == BuildingType.Industrial && !highEnd)
        {
            impactCapital = 1;
            impactPeople = 1;
            impactEnvironment = -3;
        }

        if (buildingType == BuildingType.Residential && !highEnd)
        {
            impactCapital = -3;
            impactPeople = 2;
            impactEnvironment = -2;
        }
    }
}
