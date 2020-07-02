using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundClickArea : MonoBehaviour
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
