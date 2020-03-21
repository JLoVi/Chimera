using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveSceneData : ScriptableObject, ISerializationCallbackReceiver
{
    public bool acpActive;
    public bool fungiActive;
    public bool ayucActive;
    public bool rockActive;

    [NonSerialized]
    public bool initAcpActive;
    [NonSerialized]
    public bool initFungiActive;
    [NonSerialized]
    public bool initAyucActive;
    [NonSerialized]
    public bool initRockActive;

    public void OnAfterDeserialize()
    {
        acpActive = initAcpActive;
        fungiActive = initFungiActive;
        ayucActive = initAyucActive;
        rockActive = initRockActive;
    }

    public void OnBeforeSerialize() { }
}



