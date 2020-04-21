using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyucGameManager : MonoBehaviour
{

    public delegate void ChangeTarget();
    public static event ChangeTarget OnTargetChange;

    void Start()
    {
        Cursor.visible = true;
    }

    public void ClickAction()
    {
       // Debug.Log("clickckckck");
            if (OnTargetChange != null)
            {
                OnTargetChange();
            }
    
    }
}
