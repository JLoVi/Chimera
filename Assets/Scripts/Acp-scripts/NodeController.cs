﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int id;

    public int position;
    public LocationOnMap locatonOnMap;

    [SerializeField] public TerrainNode terrainNode;
    public HoverInfoPopup popup;

    public static TerrainNode selectedNode;

    [SerializeField]
    public AcpDataHandler acpDataHandler;

    [SerializeField]
    public AcpData acpData;

    [SerializeField]
    public GameEvent updateCapital;




    private void Awake()
    {
        terrainNode = new TerrainNode
        {
            health = Random.Range(1, 100),
            price = Random.Range(1, 100),
            position = position,
            observable = true,
            purchased = false
        };

        //  acpDataHandler.t.Add(terrainNode);
        acpDataHandler.terrainNodesOnMap.Add(terrainNode);
        terrainNode.id = acpDataHandler.terrainNodesOnMap.Count;
        id = terrainNode.id;
        acpData.nodeID.Add(id);
    }
    private void Start()
    {
        popup = HoverInfoPopup.hoverInfoPopup;
        GameEventsTerrain.currentTerrainEvent.onTerrainMouseHover += OnTerrainNodeHover;
        GameEventsTerrain.currentTerrainEvent.onTerrainMouseClick += OnTerrainNodeClick;

    }

    private void OnTerrainNodeHover(int id)
    {
        // Debug.Log(terrainNode.observable);
        popup.DisplayInfo();
        if (id == this.id)
        {
            if (terrainNode != null && terrainNode.observable) Survey(id);

            if (terrainNode.purchased)
            {
                popup.infoText.text = "Already Purchased";
            }
        }
    }

    private void OnTerrainNodeClick(int id)
    {
        if (id == this.id)
        {

            if (terrainNode != null && !terrainNode.purchased) { Buy(id); }

            if (terrainNode.purchased)
            {
                popup.HideInfo();
                return;
            }
        }


    }

    private void Survey(int id)
    {
        //sx Debug.Log(terrainNode.health);
        if (!terrainNode.purchased && acpData.capital > terrainNode.price)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                  + "health: " + terrainNode.health + '\n'
                  + "cost: " + terrainNode.price
                  + '\n' + '\n' + "<Click To Buy> ";
        }

        if (!terrainNode.purchased && acpData.capital < terrainNode.price)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                  + "health: " + terrainNode.health + '\n'
                  + "cost: " + terrainNode.price
                  + '\n' + " Insufficient Funds ";
        }

        if (terrainNode.purchased)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                  + "health: " + terrainNode.health + '\n'
                  + "cost: " + terrainNode.price
                  + '\n' + " Purchased ";
        }

        //terrainNode.observable = false;

    }

    private void Buy(int id)
    {

        if (acpData.capital > terrainNode.price)
        {
            acpData.capital -= terrainNode.price;
            updateCapital.Raise();
            terrainNode.purchased = true;
            //            acpData.terrainUnitsPurcased.Add(terrainNode);

            GameEventsGlobal.currentGlobalEvent.TerrainPurchased();
            this.gameObject.AddComponent<BuildingSlots>();
            this.gameObject.GetComponent<NodeClickArea>().enabled = false;

        }
    }


}
