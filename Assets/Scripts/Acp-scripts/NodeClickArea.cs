using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClickArea : MonoBehaviour
{
    public int id;
    public Color hoverColor;
    private Renderer rend;
    public Color startColor;

    public HoverInfoPopup popup;

    void Start()
    {
        rend = GetComponent<Renderer>();
        id = GetComponent<NodeController>().terrainNode.id;
        popup = HoverInfoPopup.hoverInfoPopup;
        startColor = rend.material.color;
        CheckForActiveFungiUnits();
    }

    private void OnMouseDown()
    {
        GameEventsTerrain.currentTerrainEvent.TerrainMouseClick(id);
        popup.DisplayInfo();
    }

    void OnMouseEnter()
    {
        GameEventsTerrain.currentTerrainEvent.TerrainMouseHover(id);
        rend.material.color = hoverColor;
        popup.DisplayInfo();
    }

    void OnMouseExit()
    {
        popup.HideInfo();
        rend.material.color = startColor;
    }

    void CheckForActiveFungiUnits()
    {
        if (AcpDataHandler.acpDataHandlerInstance.fungiData.activeUnitLocations != null)
        {
            foreach (LocationOnMap location in AcpDataHandler.acpDataHandlerInstance.fungiData.activeUnitLocations)
            {
                if (GetComponent<NodeController>().locatonOnMap != null)
                {
                    if (location.name == GetComponent<NodeController>().locatonOnMap.name)
                    {
                        rend.material.color = AcpDataHandler.acpDataHandlerInstance.colorPallette.color1;
                        startColor = rend.material.color;
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
