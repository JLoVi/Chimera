using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiDataStore : MonoBehaviour
{
    [SerializeField]
    private FungiData fungiData;

    private void Start()
    {
        InitFungiData();
    }

    private void InitFungiData()
    {
        Debug.Log(fungiData.ActiveFungiObjects);
    }
}
