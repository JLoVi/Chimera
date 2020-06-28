using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFungiUnit : MonoBehaviour
{
    public FungiData fungiData;
    public LocationOnMap locationOnMap;
    public FungiUnitLifespan lifespan;

    private Animator animator;
    private bool exists;
    private bool sanitationPresent;

    [SerializeField] private float lifeTime;
    [SerializeField] private ColorPallette lifeTimeColors;


    public delegate void DeactivateAction();
    public static event DeactivateAction OnDeactivated;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lifeTime = lifespan.lifespan;
        // lifeTime = 3f;
        exists = GameManagerFungi.instance.CheckIfUnitExists(locationOnMap, exists);

        if (exists)
        {
            Activate();
        }
    }

    public void ActivateFUnit(LocationOnMap location)
    {

        if (location == GameManagerFungi.activeLocation)
        {
            Activate();
        }
    }
    public void Activate()
    {
        GetComponent<FungiUnit>().active = true;
        animator.SetTrigger("grow");
        //  StartCoroutine(ChangeColor(lifeTimeColors.color3));
        sanitationPresent = GameManagerFungi.instance.CheckIfSanitationPresent(locationOnMap, sanitationPresent);
        if (sanitationPresent)
        {
            AddFungiToData();
            StopAllCoroutines();
            StartCoroutine(KillFungi());
            Debug.Log("ff");
        }
        else
        {
            AddFungiToData();
         //   StartCoroutine(LifeSequence());
        }

    }

    public void AddFungiToData()
    {
        if (!exists)
        {
            fungiData.activeUnitLocations.Add(locationOnMap);
            lifespan.location = locationOnMap;
            fungiData.activeUnitLifespans.Add(lifespan);
            GameManagerFungi.instance.IncreaseTerritory(3f, 5f, true);
        }
    }

    public IEnumerator LifeSequence()
    {
        //   StartCoroutine(ChangeColor(lifeTimeColors.color1));
        yield return new WaitForSeconds(lifeTime * 3);
        //  StartCoroutine(ChangeColor(lifeTimeColors.color2));
        StartCoroutine(KillFungi());
        

    }

    public IEnumerator KillFungi()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(8);
        GameManagerFungi.instance.IncreaseTerritory(3f, 5f, false);
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

    public IEnumerator ChangeColor(Color endcolor)
    {
        float t = 0f;
        Color startcolor = this.gameObject.GetComponentInChildren<Renderer>().material.color;
        Color lerpColor;

        while (t < 1)
        {
            t += Time.deltaTime;

            lerpColor = Color.Lerp(startcolor, endcolor, t);
            this.gameObject.GetComponentInChildren<Renderer>().material.color = lerpColor;

            yield return null;
        }
        yield return null;
    }
}
