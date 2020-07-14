using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AYUC Data", menuName = " Ayuc Data", order = 51)]
public class AyucData : ScriptableObject
{ 
    public int numberOfUnbornChildren;
    public bool worldEnd;
}