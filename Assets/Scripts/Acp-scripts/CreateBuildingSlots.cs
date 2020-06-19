using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateBuildingSlots : MonoBehaviour
{
    [SerializeField] private int numberOfObjects;

    [SerializeField] private GameObject objectToPlace;
    private Vector3 randomPos;

    [SerializeField] private TerrainNode node;
    //  [SerializeField] private bool overlaps = false;

    //  [SerializeField] private AcpData acpData;


    void Start()
    {
    //    acpData = GetComponent<NodeController>().acpData;
        objectToPlace = GameObject.Find("BuildingSlotPrefab");
       
         node = gameObject.GetComponent<NodeController>().terrainNode;
        numberOfObjects = Mathf.RoundToInt(node.health / 10);

        StartCoroutine(SpawnBuildingSlots());

        /*
        if (a.GetComponent<Collider>().bounds.Intersects(b.GetComponent<Collider>().bounds))
        {
            Debug.Log("HHHHH");
        }
        */
    }


    public IEnumerator SpawnBuildingSlots()
    {
        for (int i = 0; i < numberOfObjects; i++)
        
        {
            

            yield return new WaitForSeconds(0.1f);
            randomPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.5f, 1.5f),
               gameObject.transform.position.y + 0.58f,
               gameObject.transform.position.z + Random.Range(-1.5f, 1.5f));

            GameObject buildingSlot = Instantiate(objectToPlace, randomPos, Quaternion.identity);
            AcpDataHandler.instance.buildingSlotGameObjects.Add(buildingSlot);


            buildingSlot.transform.localScale = buildingSlot.transform.localScale * Random.Range(0.7f, 1.4f);
            buildingSlot.transform.parent = this.transform;

            SlotController slotController = buildingSlot.AddComponent<SlotController>();
            slotController.enabled = true;
            // node.buildingSlots.Add(slotController.buildingSlot);

            

        }
           
    }
}




