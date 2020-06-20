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

    public Condition slotCondition;


    public void AddBuildingSlotData(AcpData data)
    {
        data.buildingSlots.Add(this);
    }

    public void ModifyBuildlingSlotData(AcpData data)
    {
        for (int i = 0; i < data.buildingSlots.Count; i++)
        {
            if (data.buildingSlots[i].buildingSlotID == this.buildingSlotID)
            {
                data.buildingSlots[i] = this;

            }
        }
    }
}
