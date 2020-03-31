using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiUnit : MonoBehaviour
{

    public List<GameObject> sporesInUnit;

    [SerializeField] private Animator animator;

    public LocationOnMap locationOnMap;

    [SerializeField] private GameEvent OnUnitActivated;

    [SerializeField] private FungiData fungiData;

    private FungiUnitLifespan lifeSpan;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lifeSpan = ScriptableObject.CreateInstance<FungiUnitLifespan>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "spore")
        {
            sporesInUnit.Add(other.gameObject);
            if(sporesInUnit.Count >= 3)
            {
                animator.SetTrigger("grow");

               
                lifeSpan.health = Random.Range(3, 6);
                lifeSpan.lifespan = Random.Range(3, 6);

                if (!fungiData.ActiveFungiUnits.ContainsKey(locationOnMap))
                {
                    fungiData.ActiveFungiUnits.Add(locationOnMap, lifeSpan);
                }
               /* else
                {
                    Debug.Log(locationOnMap + " location already recorded");
                }*/
                OnUnitActivated.Raise();
                

            }
        }
    }
}
