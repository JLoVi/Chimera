using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRock : MonoBehaviour
{
    public List<SoundController> soundControllers;

    public static GameManagerRock instance;

    public delegate void InitializeScene();
    public static event InitializeScene OnInitializeScene;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (OnInitializeScene != null)
        {
            OnInitializeScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
