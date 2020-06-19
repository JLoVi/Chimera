using System.Collections;
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
    public GameEvent updateCapital;

    [SerializeField]
    public GameEvent terrainNodePurchased;

    [SerializeField]
    public GameEvent updateExpenses;

    public bool observable;

    private TerrainNode CreateTerrainNode()
    {
        TerrainNode node = new TerrainNode
        {
            location = locatonOnMap,
            health = Random.Range(1, 100),
            price = Random.Range(1, 100),
            purchased = false
        };
        return node;
    }
    private void Awake()
    {
       
    }

    private void Start()
    {
        terrainNode = CreateTerrainNode();
        terrainNode.AddTerrainNodeToData(AcpDataHandler.instance.acpData);
        AcpDataHandler.instance.terrainNodesOnMap.Add(terrainNode);
        terrainNode.id = AcpDataHandler.instance.terrainNodesOnMap.Count;

        id = terrainNode.id;

        GetComponent<NodeClickArea>().id = id;

        popup = HoverInfoPopup.hoverInfoPopup;

        GameEventsTerrain.currentTerrainEvent.onTerrainMouseHover += OnTerrainNodeHover;
        GameEventsTerrain.currentTerrainEvent.onTerrainMouseClick += OnTerrainNodeClick;

    }

    private void OnTerrainNodeHover(int id)
    {
        //Debug.Log(id + "eyw"+ this.id);
        popup.DisplayInfo();
        if (id == this.id)
        {
//            Debug.Log("bbb");
            if (terrainNode != null && observable) Survey(id);

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
                HoverInfoPopup.hoverInfoPopup.HideInfo();
                return;
            }
        }
    }

    private void Survey(int id)
    {
       
        //sx Debug.Log(terrainNode.health);
        if (!terrainNode.purchased && AcpDataHandler.instance.acpData.capital > terrainNode.price)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                  + "health: " + terrainNode.health + '\n'
                  + "cost: " + terrainNode.price
                  + '\n' + '\n' + "<Click To Buy> ";
        }

        if (!terrainNode.purchased && AcpDataHandler.instance.acpData.capital < terrainNode.price)
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

        if (AcpDataHandler.instance.acpData.capital > terrainNode.price)
        {
            AcpDataHandler.instance.acpData.capital -= terrainNode.price;
            updateCapital.Raise();
            AcpDataHandler.expenses += terrainNode.price;
            updateExpenses.Raise();

            terrainNode.purchased = true;
            terrainNode.ModifyTerrainNodeData(AcpDataHandler.instance.acpData, terrainNode);
            terrainNodePurchased.Raise();

            this.gameObject.AddComponent<CreateBuildingSlots>();
            this.gameObject.GetComponent<NodeClickArea>().enabled = false;

        }
    }


}
