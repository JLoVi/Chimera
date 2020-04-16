using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotClickArea : MonoBehaviour
{
    public int id;
    public Color hoverColor;
    public Renderer rend;
    public Color startColor;

    public HoverInfoPopup popup;

    public bool selected;
    
  


    void Start()
    {
        selected = false;
        rend = GetComponent<Renderer>();
        // Debug.Log(GetComponent<NodeController>().terrainNode);
       
        popup = HoverInfoPopup.hoverInfoPopup;
        startColor = rend.material.color;
        if (GetComponent<SlotController>()!= null)
        {
            id = GetComponent<SlotController>().buildingSlot.buildingSlotID;
        }
    }

    private void OnMouseDown()
    {
        if (!selected)
        {
            AcpDataHandler.selectedBuildingSlotObject = this.gameObject;
            AcpDataHandler.selectedBuildingSlot = GetComponent<SlotController>().buildingSlot;
        //    Debug.Log("selected slot " + AcpDataHandler.selectedBuildingSlot.buildingSlotID);
        }

        selected = !selected;

        if (selected)
        {
            foreach(GameObject slot in AcpDataHandler.buildingSlotGameObjects)
            {
                if (slot != this.gameObject)
                {
                    slot.GetComponent<SlotClickArea>().selected = false;
                    slot.GetComponent<SlotClickArea>().rend.material.color = startColor;
                }
            }
        }
       
       // Debug.Log(selected);
        GameEventsBuildingSlots.currentBuildingSlotEvent.SlotMouseClick(id);
        //popup.DisplayInfo();
    }


    void OnMouseEnter()
    {
       
        GameEventsBuildingSlots.currentBuildingSlotEvent.SlotMouseHover(id);

       // popup.DisplayInfo();

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {

        popup.HideInfo();

        if(!selected) { 
        rend.material.color = startColor;
        }
    }
}
