using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsTurns : MonoBehaviour
{
    public static GameEventsTurns currentSeasonEvent;


    private void Awake()
    {
        currentSeasonEvent = this;
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
