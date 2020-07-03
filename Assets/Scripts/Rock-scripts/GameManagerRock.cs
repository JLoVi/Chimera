using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRock : MonoBehaviour
{
    public List<SoundController> soundControllers;

    public static GameManagerRock instance;

    public delegate void InitializeScene();
    public static event InitializeScene OnInitializeScene;

    public GameObject[] winProps;

    public GameObject[] scoreIcons;

    

    public GameObject winButton;

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

        foreach (GameObject go in winProps)
        {
            go.SetActive(false);
        }

        foreach (GameObject icon in scoreIcons)
        {
            icon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winbuttonFunction()
    {
        foreach (GameObject go in winProps)
        {
            go.SetActive(true);
        }

        foreach (GameObject icon in scoreIcons)
        {
            icon.SetActive(true);
           
        }

        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[0], scoreIcons[0].transform.parent);
        }
        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[1], scoreIcons[1].transform.parent);
        }
        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[2], scoreIcons[2].transform.parent);
        }
        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[3], scoreIcons[3].transform.parent);
        }
        winButton.SetActive(false);
    }

   
}
