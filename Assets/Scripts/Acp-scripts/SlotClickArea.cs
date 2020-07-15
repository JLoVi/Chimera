using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotClickArea : MonoBehaviour
{
    public int id;
    public Color hoverColor;
    public Renderer rend;
    public Color startColor;

    public HoverInfoPopup popup;

    public bool selected;

    public ActiveSceneData activeSceneData;


    void Start()
    {

        if (GameManagerAcp.instance.ayucData.worldEnd) return;
        //        Debug.Log("FSF");
        selected = false;
        rend = GetComponent<Renderer>();

        popup = HoverInfoPopup.hoverInfoPopup;
        startColor = rend.material.color;

    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
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
                foreach (GameObject slot in AcpDataHandler.instance.buildingSlotGameObjects)
                {
                    if (slot != this.gameObject && slot != null)
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
    }
    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameEventsBuildingSlots.currentBuildingSlotEvent.SlotMouseHover(id);

            // popup.DisplayInfo();

            rend.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (HoverInfoPopup.hoverInfoPopup != null)
            {
                HoverInfoPopup.hoverInfoPopup.HideInfo();
            }

            if (!selected)
            {
                rend.material.color = startColor;
            }
        }
    }

}
