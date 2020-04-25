using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDestroy : MonoBehaviour
{
    public GameEvent onUpdateBirthrate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "agent")
        {
            StartCoroutine(DestroyAgent(other.gameObject));
        }
    }

    public IEnumerator DestroyAgent(GameObject agent)
    {
        yield return new WaitForSeconds(3f);
        Destroy(agent);

        if (AyucGameManager.numberOfAgents >=1) { 
        AyucGameManager.numberOfAgents--;
        }

        AyucGameManager.birthrate++;

        onUpdateBirthrate.Raise();
    }
}
