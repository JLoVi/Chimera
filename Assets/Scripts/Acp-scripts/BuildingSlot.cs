using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BuildingSlot : TerrainNode
{
    public int buildingSlotID;
    public bool containsBuilding;
    public Building building;

    public BuildingSlot(bool contains)
    {
        this.containsBuilding = contains;
    }

    public BuildingSlot(bool contains, Building b)
    {
        this.containsBuilding = contains;
        this.building = b;
    }

}
