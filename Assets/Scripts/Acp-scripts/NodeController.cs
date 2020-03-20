using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int id;

    public int position;

    public TerrainNode terrainNode;
    public HoverInfoPopup popup;


    private void Awake()
    {
        terrainNode = ScriptableObject.CreateInstance<TerrainNode>();
        terrainNode.health = Random.Range(1, 100);
        terrainNode.price = Random.Range(1, 100);
        terrainNode.position = position;
        terrainNode.observable = true;
        terrainNode.purchased = false;

        GlobalDataStorage.terrainNodes.Add(terrainNode);

        terrainNode.id = GlobalDataStorage.terrainNodes.Count;
        id = terrainNode.id;
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
        if (!terrainNode.purchased && GlobalDataStorage.capital > terrainNode.price)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                  + "health: " + terrainNode.health + '\n'
                  + "cost: " + terrainNode.price
                  + '\n' + '\n'+ "<Click To Buy> ";
        }

        if (!terrainNode.purchased && GlobalDataStorage.capital < terrainNode.price)
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

        if (GlobalDataStorage.capital > terrainNode.price)
        {
            GlobalDataStorage.capital = GlobalDataStorage.capital - terrainNode.price;
            GameEventsGlobal.currentGlobalEvent.CapitalUpdated();
            terrainNode.purchased = true;
            GlobalDataStorage.terrainUnitsPurcased.Add(terrainNode);

            GameEventsGlobal.currentGlobalEvent.TerrainPurchased();
            this.gameObject.AddComponent<BuildingSlots>();
            this.gameObject.GetComponent<NodeClickArea>().enabled = false;



        }
    }

   
}
