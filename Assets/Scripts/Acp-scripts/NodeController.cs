using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int id;
    private bool exists;
    private bool fungiActive;
    public int position;
    public LocationOnMap locatonOnMap;

    [SerializeField] public TerrainNode terrainNode;

    public HoverInfoPopup popup;

    public static TerrainNode selectedNode;

    [SerializeField] private int slotsToSpawn;

    private Vector3 randomPos;

    private Color[] nodeCoolors;

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
        fungiActive = false;
        Color[] possibleColors = { AcpDataHandler.instance.nodeColorPallette.color1,
         AcpDataHandler.instance.nodeColorPallette.color2,
             AcpDataHandler.instance.nodeColorPallette.color3,
             AcpDataHandler.instance.nodeColorPallette.color4,
             AcpDataHandler.instance.nodeColorPallette.color5 };

        nodeCoolors = possibleColors ;

       
        AcpDataHandler.instance.terrainNodeCount++;
        terrainNode.id = id;
        CheckIfFungiActiveOnNode();
        // terrainNode.id = AcpDataHandler.instance.terrainNodeCount;

        // id = terrainNode.id;

        GetComponent<NodeClickArea>().id = id;

        exists = AcpDataHandler.instance.CheckIfNodeIdExists(terrainNode, exists);

        if (exists)
        {
            terrainNode = AcpDataHandler.instance.ReadNodeFromData(terrainNode);
            // Debug.Log(terrainNode.purchased);
        }
        else
        {
            terrainNode.AddTerrainNodeToData(AcpDataHandler.instance.acpData);
        }



        popup = HoverInfoPopup.hoverInfoPopup;



        if (terrainNode.purchased)
        {

            // this.gameObject.AddComponent<CreateBuildingSlots>();
            slotsToSpawn = AcpDataHandler.instance.numberOfSlotsOnNode(terrainNode, slotsToSpawn);
            StartCoroutine(SpawnBuildingSlots(slotsToSpawn));
            this.gameObject.GetComponent<NodeClickArea>().enabled = false;
        }
        else
        {

            slotsToSpawn = Mathf.RoundToInt(terrainNode.health / 10);

        }



        GameEventsTerrain.currentTerrainEvent.onTerrainMouseHover += OnTerrainNodeHover;
        GameEventsTerrain.currentTerrainEvent.onTerrainMouseClick += OnTerrainNodeClick;

    }

    public void CheckIfFungiActiveOnNode()
    {
        for (int i = 0; i < AcpDataHandler.instance.fungiData.activeUnitLocations.Count; i++)
        {

            if (AcpDataHandler.instance.fungiData.activeUnitLocations[i] ==
               terrainNode.location)
            {
                fungiActive = true;

                terrainNode.health /= 2;
                terrainNode.ModifyTerrainNodeData(AcpDataHandler.instance.acpData, terrainNode);
           
                AcpDataHandler.instance.CalculateTerrainHealth();
                GameManagerAcp.instance.OnTerrainHealthUpdate();

                GetComponent<Renderer>().material.color =
                    nodeCoolors[Random.Range(0, nodeCoolors.Length)];
            }
        }

        GetComponent<NodeClickArea>().startColor = GetComponent<Renderer>().material.color;
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
       

        string fungiActiveDisplay = fungiActive ? "Fungi are active in this area" : " Fungi are absent from this area";


        //sx Debug.Log(terrainNode.health);
        if (!terrainNode.purchased && AcpDataHandler.instance.acpData.capital > terrainNode.price)
        {
            popup.infoText.text = "Terrain Survey: " + '\n'
                + fungiActiveDisplay.ToString() + '\n'
                  + "location: " + terrainNode.location + '\n'
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

            StartCoroutine(SpawnBuildingSlots(slotsToSpawn));
            this.gameObject.GetComponent<NodeClickArea>().enabled = false;

        }
    }

    public IEnumerator SpawnBuildingSlots(int objectsToSpawn)
    {
        for (int i = 0; i < objectsToSpawn; i++)

        {

            yield return new WaitForSeconds(0.1f);
            randomPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.5f, 1.5f),
               gameObject.transform.position.y + 0.58f,
               gameObject.transform.position.z + Random.Range(-1.5f, 1.5f));

            GameObject buildingSlotObject = Instantiate(AcpDataHandler.instance.buildingSlotPrefab, randomPos, Quaternion.identity);
            AcpDataHandler.instance.buildingSlotGameObjects.Add(buildingSlotObject);


            buildingSlotObject.transform.localScale = buildingSlotObject.transform.localScale * Random.Range(0.7f, 1.4f);
            buildingSlotObject.transform.parent = this.transform;

            SlotController slotController = buildingSlotObject.AddComponent<SlotController>();
            slotController.enabled = true;
            // node.buildingSlots.Add(slotController.buildingSlot);
        }
    }


}
