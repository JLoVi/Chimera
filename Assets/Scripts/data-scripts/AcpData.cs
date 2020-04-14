using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New ACP Data", menuName = " ACP Data", order = 51)]
public class AcpData : ScriptableObject
{
    public bool wipeACPData;
    public bool populateData;

    public float capital;

    public List<int> nodeID;
    public List<LocationOnMap> nodeLocationOnGlobalMap;

    public List<int> nodeHealth;
    public List<int> nodePrice;
    public List<bool> nodePurchased;
   

}
