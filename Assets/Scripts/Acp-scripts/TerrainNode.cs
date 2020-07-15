using System.Collections;
using System.Collections.Generic;
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
            if (data.terrainNodes[i].id == node.id)
            {
//                Debug.Log("hr");
                data.terrainNodes[i] = node;
              


            }
        }
    }
}

