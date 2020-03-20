using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Acp.Items
{

  /*  public class InventorySlot : IDropHandler
    {// ItemSlotUI
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantityText = null;

        public override Item SlotItem
        {
//            get { return ItemSlot.item; }
            set { }
        }

        public BuildingSlot ItemSlot => inventory.GetSlotByIndex(SlotIndex);

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();

            if (itemDragHandler == null) { return; }

           
        }

        public override void UpdateSlotUI()
        {
  //          if (ItemSlot.item == null)
            {
                EnableSlotUI(false);
                return;
            }

            EnableSlotUI(true);

//            itemIconImage.sprite = ItemSlot.item.Icon;
   //         itemQuantityText.text = ItemSlot.health > 1 ? ItemSlot.health.ToString() : "";
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
            itemQuantityText.enableAutoSizing = enable;
        }
    }*/
}
