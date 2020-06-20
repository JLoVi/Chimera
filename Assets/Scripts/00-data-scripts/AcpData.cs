using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ACP Data", menuName = " ACP Data", order = 51)]
public class AcpData : ScriptableObject
{
    public bool wipeACPData;
  //  public bool populateNodes;

    public float capital;
    public int socialScore;
    public int environmentScore;
    public int economicGrowth;

    public int seasonLength;

    public List<TerrainNode> terrainNodes;
    public List<BuildingSlot> buildingSlots;
   
}
