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
        rend = GetComponent<Renderer>();
      //  id = GetComponent<NodeController>().terrainNode.id;
        //rend.material.color = AcpDataHandler.instance.nodeColorPallette.color1;

        popup = HoverInfoPopup.hoverInfoPopup;
        
        //   CheckForActiveFungiUnits();
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameEventsTerrain.currentTerrainEvent.TerrainMouseClick(id);
            popup.DisplayInfo();
        }
    }

    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameEventsTerrain.currentTerrainEvent.TerrainMouseHover(id);
            rend.material.color = hoverColor;
            popup.DisplayInfo();
        }
    }

    void OnMouseExit()
    {
        HoverInfoPopup.hoverInfoPopup.HideInfo();
        rend.material.color = startColor;
    }


}
