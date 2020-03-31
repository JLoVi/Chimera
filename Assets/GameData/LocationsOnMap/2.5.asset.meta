using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiUnit : MonoBehaviour
{

    public List<GameObject> sporesInUnit;
    [SerializeField] private Animator animator;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hey");
        if(other.gameObject.tag == "spore")
        {
            sporesInUnit.Add(other.gameObject);
            if(sporesInUnit.Count >= 3)
            {
                animator.SetTrigger("grow");
            }
        }
    }
}
