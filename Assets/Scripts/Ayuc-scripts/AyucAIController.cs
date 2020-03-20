using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AyucAIController : MonoBehaviour
{

    public GameObject[] targets;
    NavMeshAgent agent;

    void OnEnable()
    {
        AyucGameManager.OnTargetChange += changeTarget;
    }


    void OnDisable()
    {
        AyucGameManager.OnTargetChange -= changeTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("ayuc-target");
        agent = this.GetComponent<NavMeshAgent>();
        if (targets != null) {
            agent.SetDestination(targets[Random.Range(0, 1)].transform.position);
        }
    }

   public void changeTarget()
   {
        agent.SetDestination(targets[Random.Range(0, targets.Length - 1)].transform.position);
   }
}
