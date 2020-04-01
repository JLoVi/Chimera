using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFungiUnit : MonoBehaviour
{
    public FungiData fungiData;
    public LocationOnMap locationOnMap;
    public FungiUnitLifespan lifespan;

    [SerializeField] private Animator animator;
    public void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }
    public void ActivateFUnit(LocationOnMap location)
    {
        if (location == GameManagerFungi.activeLocation)
        {
            Debug.Log("location to activate unit at: " + locationOnMap);

            animator.SetTrigger("grow");

            fungiData.activeUnitLifespans.Add(lifespan);
            fungiData.activeUnitLocations.Add(locationOnMap);
        }
    }
}
