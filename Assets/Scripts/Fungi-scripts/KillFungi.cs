using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFungi : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private GameEvent OnFungiDeactivated;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void DeactivateFungi()
    {
        animator.SetTrigger("die");
        OnFungiDeactivated.Raise();
    }

}
