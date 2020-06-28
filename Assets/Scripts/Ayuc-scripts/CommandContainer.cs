using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CommandContainer : ScriptableObject
{
    public List<CommandResponse> commands;

    public List<string> sequenceOne;
    public List<string> sequenceTwo;
    public List<string> sequenceThree;
    public List<string> sequenceFour;
}
