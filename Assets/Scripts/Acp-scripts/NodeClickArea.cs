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
       // Debug.Log(GetComponent<NodeController>().terrainNode);
        id = GetComponent<NodeController>().terrainNode.id;
        popup = HoverInfoPopup.hoverInfoPopup;
        startColor = rend.material.color;

    }

    private void OnMouseDown()
    {
        
        GameEventsTerrain.currentTerrainEvent.TerrainMouseClick(id);
        //popup.DisplayInfo();
    }


    void OnMouseEnter()
    {
       
        GameEventsTerrain.currentTerrainEvent.TerrainMouseHover(id);

      //  popup.DisplayInfo();

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        popup.HideInfo();

        rend.material.color = startColor;
    }
}
