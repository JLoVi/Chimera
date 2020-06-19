using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAcp : MonoBehaviour
{
    public AcpData acpData;

    //CAPITAL AND SCORES
    public Text capitalText;
    public Text socialText;
    public Text environmentText;
    public Text economicText;

    //TERRAIN INFO
    public Text terrainHealthText;
    public Text terrainNodesPurchasedText;

    //INFRASTRUCTURE INFO
    public Text residentialText;
    public Text industrialText;
    public Text financialText;

    //FINANCIAL INFO
    public Text expensesText;
    public Text maintenanceText;

    

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
        acpData.socialScore = 0;
        acpData.environmentScore = 0;
        acpData.economicGrowth = 0;
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

        socialText.text = "Social Score: " + acpData.socialScore;
        environmentText.text = "Environmental Sustainability: " + acpData.environmentScore;
        economicText.text = "Economic Growth: " + acpData.economicGrowth;
    }

    public void OnUpdateExpenses()
    {
        expensesText.text = "Expenses: " + AcpDataHandler.expenses;
    }

    public void UpdateMaintenance()
    {
        maintenanceText.text = "Seasonal Maintenance Fees: " + AcpDataHandler.maintenanceFees;
    }

    void CheckForActiveFungiUnits()
    {
        if (AcpDataHandler.instance.fungiData.activeUnitLocations != null)
        {
            foreach (LocationOnMap location in AcpDataHandler.instance.fungiData.activeUnitLocations)
            {
                if (GetComponent<NodeController>().locatonOnMap != null)
                {
                    if (location.name == GetComponent<NodeController>().locatonOnMap.name)
                    {
                       // rend.material.color = AcpDataHandler.acpDataHandlerInstance.colorPallette.color1;
                       // startColor = rend.material.color;
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
