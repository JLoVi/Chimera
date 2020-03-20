using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Acp.Items
{
    public interface IItemContainer
    {
        BuildingSlot AddItem(BuildingSlot itemSlot);
        void RemoveItem(BuildingSlot itemSlot);
        void RemoveAt(int slotIndex);
        bool HasItem(InventoryItem item);
        int GetTotalQuantity(InventoryItem item);
    }
}

