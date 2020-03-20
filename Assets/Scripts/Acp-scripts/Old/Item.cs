using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Acp.Items
{ 
    public abstract class Item : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] private new string name = "New Item Name";
        [SerializeField] private Sprite icon = null;

        public string Name => name;
        public abstract string BuildingName { get; }

        public Sprite Icon => icon;

        public abstract string GetInfoDisplayText();
    }
}
