using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Building", menuName = "Items/Building")]

public class BuildingSlot : ScriptableObject

{


    public int id;
    public GameObject slotMesh;
    public int price;
    public int maintinence;
    public bool highEnd;
    public BuildingType buildingType;
    public GameObject buildingMesh;
    public int impactEnvironment;
    public int impactPeople;
    public int impactCapital;
    public bool containsBuilding;


    public BuildingSlot(int Id, GameObject slot, int pri, int maint, bool high, BuildingType buildingT, GameObject buildingM, int impactEnv, int impactP, int impactC, bool contains)

    {
        id = Id;
        slotMesh = slot;
        price = pri;
        maintinence = maint;
        highEnd = high;
        buildingType = buildingT;
        buildingMesh = buildingM;
        impactEnvironment = impactEnv;
        impactPeople = impactP;
        impactCapital = impactC;
        containsBuilding = contains;
    }

    // Constructor
    public BuildingSlot()
    {
        id = 0;
        slotMesh = null;
        price = 0;
        maintinence = 0;
        highEnd = false;
        buildingType = BuildingType.Residential;
        buildingMesh = null;
        impactEnvironment = 0;
        impactPeople = 0;
        impactCapital = 0;
        containsBuilding = false;
    }
}
