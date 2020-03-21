using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fungi Data", menuName = " Fungi Data", order = 51)]

public class FungiData : ScriptableObject
{
    [SerializeField]
    private List<GameObject> activeFungiObjects;

    [SerializeField]
    private List<Vector3> activeFungiPositions;

    [SerializeField]
    private float fungiTerritoryOccupied;

    //how old are the organisms / lifetime
    [SerializeField]
    private float fungiHealth;


    public List<GameObject> ActiveFungiObjects
    {
        get
        {
            return activeFungiObjects;
        }
    }

    public List<Vector3> ActiveFungiPositions
    {
        get;
       // {
        //    return activeFungiPositions;
       // }
    }
}
