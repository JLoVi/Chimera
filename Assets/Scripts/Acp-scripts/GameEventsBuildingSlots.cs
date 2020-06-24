using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventsBuildingSlots : MonoBehaviour
{
    public static GameEventsBuildingSlots currentBuildingSlotEvent;


    private void Awake()
    {
        currentBuildingSlotEvent = this;
    }

    public event Action<int> onSlotMouseClick;
    public void SlotMouseClick(int id)
    {
        if (onSlotMouseClick != null)
        {
            onSlotMouseClick(id);
        }
    }

    public event Action<int> onSlotMouseHover;

    public void SlotMouseHover(int id)
    {
        if (onSlotMouseHover != null)
        {
            onSlotMouseHover(id);
        }
    }


    public event Action<LocationOnMap, bool> onRecoverFromAttack;

    public void RecoverFromAttack(LocationOnMap location, bool fungiactive)
    {
        if (onRecoverFromAttack != null)
        {
            onRecoverFromAttack(location, fungiactive);
        }
    }


}
