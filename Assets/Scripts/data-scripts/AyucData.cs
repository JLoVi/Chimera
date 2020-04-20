using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AYUC Data", menuName = " Ayuc Data", order = 51)]
public class AyucData : ScriptableObject
{ 
    public List<CommandResponse> commandResponses;

}