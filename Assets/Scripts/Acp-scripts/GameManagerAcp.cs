using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAcp : MonoBehaviour
{
    public AcpData acpData;

    //CAPITAL AND SCORES
    public Text capitalText;

    //TERRAIN INFO
    public Text terrainHealthText;
    public Text terrainNodesPurchasedText;

    //INFRASTRUCTURE INFO
    public Text residentialText;
    public Text industrialText;
    public Text financialText;

    // Start is called before the first frame update
    private void Awake()
    {
        if (acpData.wipeACPData) WipeAcpData();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void WipeAcpData()
    {
        acpData.terrainNodes.Clear();
        acpData.buildingSlots.Clear();
    }

    public void UpdateCapitalText()
    {
        capitalText.text = "Total Capital Revenues: " + Mathf.RoundToInt(acpData.capital);
    }

    public void OnTerrainHealthUpdate()
    {
        terrainHealthText.text = "Terrain Health: " + AcpDataHandler.terrainHealth;
    }

    public void OnTerrainPurchased()
    {
        terrainNodesPurchasedText.text = "Terrain Nodes Purchased: " + AcpDataHandler.terrainNodesPurchased;
       // Debug.Log("TERRAINPURCHASED");

    }

    public void OnBuildingPurchased()
    {
        residentialText.text = "Residential: " + AcpDataHandler.residentialAmt;
        industrialText.text = "Industrial: " + AcpDataHandler.industrialAmt;
        financialText.text = "Financial: " + AcpDataHandler.financialAmt;
    }
}
