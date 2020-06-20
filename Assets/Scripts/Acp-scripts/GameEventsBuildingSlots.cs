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


   /* public event Action<int> onFungiPresent;

    public void FungiPresent(int id)
    {
        if (onFungiPresent != null)
        {
            onFungiPresent(id);
        }
    }*/


}
