using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Acp.Items
{
   /* public class ItemDestroyer : MonoBehaviour
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI areYouSureText = null;

        private int slotIndex = 0;

        private void OnDisable() => slotIndex = -1;

        public void Activate(BuildingSlot itemSlot, int slotIndex)
        {
            this.slotIndex = slotIndex;

            areYouSureText.text = $"Are you sure you wish to sell {itemSlot.item} $$$ {itemSlot.price} ?";

            gameObject.SetActive(true);
        }

        public void Destroy()
        {
            inventory.RemoveAt(slotIndex);

            gameObject.SetActive(false);
        }
    }*/
}
