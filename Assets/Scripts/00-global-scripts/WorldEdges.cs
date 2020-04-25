using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEdges : MonoBehaviour
{
    public static string edge;

    [SerializeField]
    private GameEvent OnWorldEdges;

    [SerializeField]
    private string camtag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == camtag)
        {
            OnWorldEdges.Raise();
            edge = gameObject.name;
        }
    }
}
