using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFungiUnit : MonoBehaviour
{
    public FungiData fungiData;
    public LocationOnMap locationOnMap;
    public FungiUnitLifespan lifespan;

    private Animator animator;

    [SerializeField] private float lifeTime;


    public delegate void DeactivateAction();
    public static event DeactivateAction OnDeactivated;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lifeTime = lifespan.lifespan;
        // lifeTime = 3f;
    }

    public void ActivateFUnit(LocationOnMap location)
    {
        if (location == GameManagerFungi.activeLocation)
        {
            foreach (LocationOnMap loc in fungiData.activeUnitLocations)
            {
                if (loc != location) { 
                GetComponent<FungiUnit>().active = true;
                animator.SetTrigger("grow");
                fungiData.activeUnitLifespans.Add(lifespan);
                fungiData.activeUnitLocations.Add(locationOnMap);
                StartCoroutine(LifeSequence());
                }
            }
        }
    }

    public IEnumerator LifeSequence()
    {
        yield return new WaitForSeconds(lifeTime * 3);
        animator.SetTrigger("die");
        yield return new WaitForSeconds(5);
        ResetData();
    }

    public void ResetData()
    {
        GameManagerFungi.deadLifespan = lifespan;
        GameManagerFungi.deadLocation = locationOnMap;
        GetComponent<FungiUnit>().sporesInUnit.Clear();
        GetComponent<FungiUnit>().active = false;
        OnDeactivated();
    }
}
