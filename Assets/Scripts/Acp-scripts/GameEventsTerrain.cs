using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventsTerrain : MonoBehaviour
{

    public static GameEventsTerrain currentTerrainEvent;


    private void Awake()
    {
        currentTerrainEvent = this;
    }

    public event Action<int> onTerrainMouseClick;
    public void TerrainMouseClick(int id)
    {
        if (onTerrainMouseClick != null)
        {
            onTerrainMouseClick(id);
        }
    }

    public event Action<int> onTerrainMouseHover;

    public void TerrainMouseHover(int id)
    {
        if (onTerrainMouseHover != null)
        {
            onTerrainMouseHover(id);
        }
    }

    public event Action<int> onTerrainNodePurchased;

    public void TerrainNodePurchased(int id)
    {
        if (onTerrainNodePurchased != null)
        {
            onTerrainNodePurchased(id);
        }
    }
}
