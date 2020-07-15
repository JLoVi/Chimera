using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeClickArea : MonoBehaviour
{
    public int id;
    public Color hoverColor;
    private Renderer rend;
    public Color startColor;

    public HoverInfoPopup popup;

    private void Awake()
    {
        

    }
    void Start()
    {
        if (GameManagerAcp.instance.ayucData.worldEnd) return;
        rend = GetComponent<Renderer>();
      //  id = GetComponent<NodeController>().terrainNode.id;
        //rend.material.color = AcpDataHandler.instance.nodeColorPallette.color1;

        popup = HoverInfoPopup.hoverInfoPopup;
        
        //   CheckForActiveFungiUnits();
    }

    private void OnMouseDown()
    {
        if (GameManagerAcp.instance.ayucData.worldEnd && !GameManagerAcp.instance.ayucData.worldEnd) return;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameEventsTerrain.currentTerrainEvent.TerrainMouseClick(id);
            popup.DisplayInfo();
        }
    }

    void OnMouseEnter()
    {
        if (GameManagerAcp.instance.ayucData.worldEnd) return;
        if (!EventSystem.current.IsPointerOverGameObject() && !GameManagerAcp.instance.ayucData.worldEnd)
        {
            GameEventsTerrain.currentTerrainEvent.TerrainMouseHover(id);
            rend.material.color = hoverColor;
            popup.DisplayInfo();
        }
    }

    void OnMouseExit()
    {
        if (GameManagerAcp.instance.ayucData.worldEnd) return;
        HoverInfoPopup.hoverInfoPopup.HideInfo();
        rend.material.color = startColor;
    }


}
