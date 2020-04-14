using System.Collections;
using UnityEngine;

[System.Serializable]
public class TerrainNode
{
    //immutable
    public int id;
    public LocationOnMap location;

    //variable
    public int health;
    public int price;
   
    public bool purchased;

    public void AddTerrainNodeToData(AcpData data)
    {
        data.nodeID.Add(id);
        data.nodeLocationOnGlobalMap.Add(location);
        data.nodeHealth.Add(health);
        data.nodePrice.Add(price);
        data.nodePurchased.Add(purchased);
    }

    public void ModifyTerrainNodeData(AcpData data)
    {
        for (int i = 0; i < data.nodeID.Count; i++)
        {
            if (i == id)
            {
                data.nodeHealth[i] = health;
                data.nodePrice[i] = price;
                data.nodePurchased[i] = purchased;
            }
        }
    }
}

