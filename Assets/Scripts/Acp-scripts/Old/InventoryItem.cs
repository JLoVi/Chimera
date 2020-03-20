using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Acp.Items
{
    public abstract class InventoryItem : Item
    {
        [Header("Item Data")]
        [SerializeField] private Building building = null;
        [SerializeField][Min(0)] private int sellPrice = 1;
        [SerializeField][Min(1)] private int maxStack = 1;

        public override string BuildingName
        {
            get
            {
                return $"<color=#{ColorUtility.ToHtmlStringRGB(Color.blue)}>{Name}</color>";
            }
        }
        public int SellPrice => sellPrice;
        public int MaxStack => maxStack;

        public Building Building => building;
    }
}