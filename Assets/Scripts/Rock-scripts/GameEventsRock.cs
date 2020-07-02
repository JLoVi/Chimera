using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventsRock : MonoBehaviour
{
    public static GameEventsRock currentRockEvent;


    private void Awake()
    {
        currentRockEvent = this;
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
}
