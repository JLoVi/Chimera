using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsGlobal : MonoBehaviour
{
    public static GameEventsGlobal currentGlobalEvent;


    private void Awake()
    {
        currentGlobalEvent = this;
    }

    /*public event Action onCapitalUpdated;
    public void CapitalUpdated()
    {
        if (onCapitalUpdated != null)
        {
            onCapitalUpdated();
        }
    }*/

   /* public event Action onTerrainPurchased;
    public void TerrainPurchased()
    {
        if (onTerrainPurchased != null)
        {
            onTerrainPurchased();
        }
    }*/

    public event Action onBuildingPurchased;
    public void BuildingPurchased()
    {
        if (onBuildingPurchased != null)
        {
            onBuildingPurchased();
        }
    }

    public event Action onSeasonBegin;
    public void SeasonBegin()
    {
        if (onSeasonBegin != null)
        {
            onSeasonBegin();
        }
    }

    public event Action onSeasonEnd;
    public void SeasonEnd()
    {
        if (onSeasonEnd != null)
        {
            onSeasonEnd();
        }
    }

}
