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
            sporesInUnit.Add(other.gameObject);

            if (sporesInUnit.Count > 3)
            {
                return;
            }
            if (sporesInUnit.Count == 3)
            {
                if (!active)
                {
                    OnUnitActivated.Raise();
                    active = true;
                }
                else { return; }

            }

        }
    }
}

