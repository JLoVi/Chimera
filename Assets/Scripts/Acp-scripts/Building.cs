using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Acp Building", menuName = "Items/AcpBuilding")]

public class Building : ScriptableObject
{
    public int constructitonCost;
    public int maintenanceCost;
    public bool highEnd;
    public BuildingType buildingType;
    public GameObject buildingMesh;
    public int impactEnvironment;
    public int impactPeople;
    public int impactCapital;
}
