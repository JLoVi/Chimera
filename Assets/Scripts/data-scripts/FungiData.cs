using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fungi Data", menuName = " Fungi Data", order = 51)]

public class FungiData : ScriptableObject
{

    public List <LocationOnMap> activeUnitLocations  = new List<LocationOnMap>();

    public List <FungiUnitLifespan> activeUnitLifespans = new List<FungiUnitLifespan>();

}
