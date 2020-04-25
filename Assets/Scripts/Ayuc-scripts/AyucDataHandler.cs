using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyucDataHandler : MonoBehaviour
{
    public RockData rockData;

    public static GameObject ayucRuntimeAssetParent;

    // Start is called before the first frame update
    void Start()
    {
        ayucRuntimeAssetParent = GameObject.Find("AYUC-runtime-assets");

        if (ayucRuntimeAssetParent != null)
        {
            Debug.Log(ayucRuntimeAssetParent.name + " ++ AYUC runtime parent found!");
            rockData.ayucRuntimeAssets = ayucRuntimeAssetParent;
        }
        else
        {
            Debug.LogError(ayucRuntimeAssetParent + " AYUC runtime parent NOT FOUND!");
        }
    }
}
