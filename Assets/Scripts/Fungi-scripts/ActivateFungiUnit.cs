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
        DisplayChildren(transform, lifeTimeColors.color1);

        //  StartCoroutine(ChangeColor(lifeTimeColors.color3));
        sanitationPresent = GameManagerFungi.instance.CheckIfSanitationPresent(locationOnMap, sanitationPresent);
        if (sanitationPresent)
        {
            AddFungiToData();
            StopAllCoroutines();
            StartCoroutine(KillFungi());
           // Debug.Log("ff");
        }
        else
        {
            AddFungiToData();
            StartCoroutine(LifeSequence());
        }

    }

    public void AddFungiToData()
    {
        if (!exists)
        {
            fungiData.activeUnitLocations.Add(locationOnMap);
            lifespan.location = locationOnMap;
            fungiData.activeUnitLifespans.Add(lifespan);
            GameManagerFungi.instance.IncreaseTerritory(3f, 6f);
        }
    }

    public IEnumerator LifeSequence()
    {
        //   StartCoroutine(ChangeColor(lifeTimeColors.color1));
        yield return new WaitForSeconds(lifeTime * 10);
       
        StartCoroutine(KillFungi());


    }

    public IEnumerator KillFungi()
    {
        animator.SetTrigger("die");
        DisplayChildren(transform, lifeTimeColors.color4);
        yield return new WaitForSeconds(3);
        DisplayChildren(transform, lifeTimeColors.color2);
        yield return new WaitForSeconds(4);
        DisplayChildren(transform, lifeTimeColors.color3);
        yield return new WaitForSeconds(4);
        DisplayChildren(transform, lifeTimeColors.color2);
        yield return new WaitForSeconds(1);

        GameManagerFungi.instance.DecreaseTerritory(3f, 6f);
        ResetData();
    }

    void DisplayChildren(Transform trans, Color color)
    {
        foreach (Transform child in trans)
        {
            StartCoroutine(ChangeColor(color,child.gameObject));
            if (child.childCount > 0)
            {
                DisplayChildren(child, color);
            }
        }
    }

    public void ResetData()
    {
        GameManagerFungi.deadLifespan = lifespan;
        GameManagerFungi.deadLocation = locationOnMap;
        GetComponent<FungiUnit>().sporesInUnit.Clear();
        GetComponent<FungiUnit>().active = false;
        OnDeactivated();
    }

    public IEnumerator ChangeColor(Color endcolor, GameObject child)
    {
        float t = 0f;
        if (child.GetComponent<Renderer>() != null)
        {
            Color startcolor = child.GetComponent<Renderer>().material.color;

            Color lerpColor;

            while (t < 5)
            {
                t += Time.deltaTime;

                lerpColor = Color.Lerp(startcolor, endcolor, t);
                child.GetComponentInChildren<Renderer>().material.color = lerpColor;

                yield return null;
            }
        }
        yield return null;
    }
}
