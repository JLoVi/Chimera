using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAcp : MonoBehaviour
{
    public AcpData acpData;
    public Text capitalText;
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

    public void UpdateCapitalText()
    {
        capitalText.text = "Total Capital Revenues: " + Mathf.RoundToInt(acpData.capital);
    }

    public void WipeAcpData()
    {
        acpData.nodeID.Clear();
    }
}
