using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AyucNavAgentStore : ScriptableObject
{
    public GameObject[] agentMeshes;

    public Transform[] targets;
}
