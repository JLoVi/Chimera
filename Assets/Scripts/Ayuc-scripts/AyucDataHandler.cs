using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyucDataHandler : MonoBehaviour
{
    public GameObject ayucRuntimeAssetParent;

    // Start is called before the first frame update
    void Start()
    {
        ayucRuntimeAssetParent = GameObject.Find("AYUC-runtime-assets");

        if (ayucRuntimeAssetParent != null)
        {
            Debug.Log(ayucRuntimeAssetParent + " AYUC runtime parent found!");
        }
        else
        {
            Debug.LogError(ayucRuntimeAssetParent + " AYUC runtime parent NOT FOUND!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
