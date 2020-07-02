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

    public event Action<int> onRockPropMouseClick;
    public void RockPropMouseClick(int id)
    {
        if (onRockPropMouseClick != null)
        {
            onRockPropMouseClick(id);
        }
    }

    public event Action<int> onRockPropMouseHover;

    public void RockPropMouseHover(int id)
    {
        if (onRockPropMouseHover != null)
        {
            onRockPropMouseHover(id);
        }
    }
}
