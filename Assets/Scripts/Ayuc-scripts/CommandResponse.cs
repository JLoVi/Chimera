using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "Items/Command")]
public class CommandResponse : ScriptableObject
{
    public string command;

    public string[] wordResponse;

}
