using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingSlots : MonoBehaviour
{
    [SerializeField] private int numberOfObjects;

    [SerializeField] private GameObject objectToPlace;
    private Vector3 randomPos;

    [SerializeField] private bool overlaps = false;


    // public GameObject a;
    // public GameObject b;
    public List<GameObject> buildingSlots = new List<GameObject>();

    void Start()
    {
        objectToPlace = GameObject.Find("BuildingSlotPrefab");
        // Debug.Log(GameObject.Find("BuildingSlotPrefab"));
       // transform.GetChild(0).gameObject.SetActive(true);

        numberOfObjects = Mathf.RoundToInt(gameObject.GetComponent<NodeController>().terrainNode.health / 10);

        StartCoroutine(SpawnBuildingSlots());
        /*
                if (a.GetComponent<Collider>().bounds.Intersects(b.GetComponent<Collider>().bounds))
                {
                    Debug.Log("HHHHH");
                }*/

    }


    public IEnumerator SpawnBuildingSlots()
    {
        for (int i = 0; i < numberOfObjects; i++)

        {
            yield return new WaitForSeconds(0.1f);
            randomPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.5f, 1.5f),
               gameObject.transform.position.y + 0.58f,
               gameObject.transform.position.z + Random.Range(-1.5f, 1.5f));

            // Instantiate(objectToPlace, new Vector3(randomX, randomY, randomZ))
            GameObject buildingSlot = Instantiate(objectToPlace, randomPos, Quaternion.identity);
            buildingSlots.Add(buildingSlot);
            GlobalDataStorage.buildingSlotGameObjects.Add(buildingSlot);

            buildingSlot.transform.localScale = buildingSlot.transform.localScale * Random.Range(0.7f, 1.4f);
            buildingSlot.transform.parent = this.transform;
            buildingSlot.AddComponent<SlotController>();


            CheckIfOverlap();
            while (overlaps)
            {
                randomPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.5f, 1.5f),
                    gameObject.transform.position.y + 0.58f,
                    gameObject.transform.position.z + Random.Range(-1.5f, 1.5f));

                objectToPlace.transform.position = randomPos;
                CheckIfOverlap();
            }
        }
    }

    public void CheckIfOverlap()
    {

        foreach (GameObject slot in buildingSlots)
        {
          //  Debug.Log(slot);
            //Debug.Log("check");
            if (objectToPlace.GetComponent<Collider>().bounds.Intersects(slot.GetComponent<Collider>().bounds))
            {
                overlaps = true;
                 Debug.Log("overlaps");
            }

        }

    }
}


