using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFungiUnit : MonoBehaviour
{
    public FungiData fungiData;
    public LocationOnMap locationOnMap;
    public FungiUnitLifespan lifespan;

    private Animator animator;

    [SerializeField] private GameEvent OnFungiDead;
    [SerializeField] private float lifeTime;


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
            // Debug.Log("location to activate unit at: " + locationOnMap);

            GetComponent<FungiUnit>().active = true;
            animator.SetTrigger("grow");

            fungiData.activeUnitLifespans.Add(lifespan);
            fungiData.activeUnitLocations.Add(locationOnMap);
            StartCoroutine(LifeSequence());
        }
    }

    public IEnumerator LifeSequence()
    {
        yield return new WaitForSeconds(lifeTime * 3);
        OnFungiDead.Raise();
    }

    public void RemoveFungiData()
    {
        for (int i = 0; i < fungiData.activeUnitLocations.Count-1; i++)
        {
            if (fungiData.activeUnitLocations[i].name == locationOnMap.name)
            {
                fungiData.activeUnitLocations.RemoveAt(i);
            }
        }
    }
}
