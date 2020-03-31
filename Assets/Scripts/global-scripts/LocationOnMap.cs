using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LocationOnMap : ScriptableObject
{
    [SerializeField]
    private float location;

    public float Location
    {
        get
        {
            return location;
        }
    }
}
