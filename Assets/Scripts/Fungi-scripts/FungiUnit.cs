using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FungiUnit : MonoBehaviour
{
   
    public List<GameObject> sporesInUnit;

    [SerializeField] private GameEvent OnUnitActivated;

    public bool active;

    public void OnTriggerEnter(Collider other)
    {
        GameManagerFungi.activeLocation = GetComponent<ActivateFungiUnit>().locationOnMap;
        if (other.gameObject.tag == "spore")
        {
            if (sporesInUnit.Count < 3)
            {
                sporesInUnit.Add(other.gameObject);
            }
            if (sporesInUnit.Count > 3)
            {
                return;
            }
            if (sporesInUnit.Count == 3)
            {
                if (!active)
                {
                    OnUnitActivated.Raise();
                }
                else { return; }
            }
        }
    }

    public void ReactivateFungi()
    {
        StartCoroutine(ResetData());
    }

    public IEnumerator ResetData()
    {
        yield return new WaitForSeconds(10);
        sporesInUnit.Clear();
        active = false;
    }
}

