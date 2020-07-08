using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAcp : MonoBehaviour
{
    public AcpData acpData;

    //CAPITAL AND SCORES
    public Text capitalTargetText;
    public Text capitalText;
    public Text socialText;
    public Text environmentText;
    public Text economicText;

    //TERRAIN INFO
    public Text terrainHealthText;
    public Text terrainNodesPurchasedText;

    //INFRASTRUCTURE INFO
    public Text residentialBText;
    public Text industrialBText;
    public Text financialBText;
    public Text socialBText;
    public Text sanitationBText;

    //FINANCIAL INFO
    public Text expensesText;
    public Text maintenanceText;

    public static GameManagerAcp instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        if (acpData.wipeACPData) WipeAcpData();
    }

    void Start()
    {
        OnUpdateExpenses();
        UpdateMaintenance();
        AcpDataHandler.instance.CalculateTargetCapital();
        UpdateCapitalTargetText();


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

    public void UpdateCapitalTargetText()
    {
        capitalTargetText.text = "TARGET CAPITAL: " + AcpDataHandler.instance.targetCapital;
    }

    public void UpdateCapitalText()
    {
        capitalText.text = "TOTAL CAPITAL REVENUES: " + Mathf.RoundToInt(acpData.capital);
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
        residentialBText.text = "Residential: " + AcpDataHandler.residentialAmt;
        industrialBText.text = "Industrial: " + AcpDataHandler.industrialAmt;
        financialBText.text = "Financial: " + AcpDataHandler.financialAmt;
        socialBText.text = "Social: " + AcpDataHandler.socialAmt;
        sanitationBText.text = "Sanitation: " + AcpDataHandler.sanitationAmt;

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


    public bool CheckForActiveFungiUnits(BuildingSlot slot, bool state)
    {

        state = false;
        if (AcpDataHandler.instance.fungiData.activeUnitLocations != null)
        {
            for (int i = 0; i < AcpDataHandler.instance.fungiData.activeUnitLocations.Count; i++)
            {
               
                if (AcpDataHandler.instance.fungiData.activeUnitLocations[i] == slot.location)
                {
                    
                    state = true;
//                    Debug.Log(slot.location);

                }
            }
        }
        return state;

    }

}
