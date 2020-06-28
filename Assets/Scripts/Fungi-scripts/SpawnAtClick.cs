using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtClick : MonoBehaviour
{
    // [SerializeField] private GameEvent OnTerritoryIncrease;
    public GameObject spore;
    public Camera fungicam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            var ray = fungicam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "fungi")
                {

                    float altitude = Random.Range(-3f, 0f);
                    Instantiate(spore, new Vector3(hit.point.x, hit.point.y + altitude, hit.point.z), Quaternion.identity, GameManagerFungi.fungiRuntimeAssetParent.transform);
                    GameManagerFungi.instance.IncreaseTerritory(0.1f, 0.3f, true);
                }
            }
        }
    }
}
