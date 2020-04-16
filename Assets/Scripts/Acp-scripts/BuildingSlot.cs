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

    public void AddBuildingSlotData(AcpData data)
    {
        data.buildingSlots.Add(this);
    }

    public void ModifyBuildingSlotData(AcpData data, BuildingSlot slot)
    {
        for (int i = 0; i < data.buildingSlots.Count; i++)
        {
            if (i == slot.buildingSlotID)
            {
                data.buildingSlots[i] = slot;

            }
        }
    }

}
