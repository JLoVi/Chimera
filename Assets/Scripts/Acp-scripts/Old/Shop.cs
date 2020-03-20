using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    // Start is called before the first frame update
    public void PurchaseA()
    {
        Debug.Log("A");
        buildManager.SetTurretToBuild(buildManager.buildingA);
    }

    // Update is called once per frame
    public void PurchaseB() 
    {
        Debug.Log("B");
        buildManager.SetTurretToBuild(buildManager.buildingB);
    }

    public void PurchaseC()
    {
        Debug.Log("C");
        buildManager.SetTurretToBuild(buildManager.buildingC);
    }
}
