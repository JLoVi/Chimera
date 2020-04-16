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
        data.terrainNodes.Add(this);
    }

    public void ModifyTerrainNodeData(AcpData data, TerrainNode node)
    {
        for (int i = 0; i < data.terrainNodes.Count; i++)
        {
            if (i == node.id)
            {
                data.terrainNodes[i] = node;
                
            }
        }
    }
}

