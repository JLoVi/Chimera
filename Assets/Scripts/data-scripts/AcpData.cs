using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New ACP Data", menuName = " ACP Data", order = 51)]
public class AcpData : ScriptableObject
{
    public bool wipeACPData;
    public bool populateData;

    public float capital;

    public List<TerrainNode> terrainNodes;
    public List<BuildingSlot> buildingSlots;
   
}
