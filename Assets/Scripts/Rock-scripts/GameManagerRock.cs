using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRock : MonoBehaviour
{
    public FungiData fungiData;

    public List<SoundController> soundControllers;

    public static GameManagerRock instance;

    public delegate void InitializeScene();
    public static event InitializeScene OnInitializeScene;

    public GameObject[] winProps;

    public GameObject[] scoreIcons;

    public GameObject[] fungiPieces;
    public int numberOfFungiToSpawn;

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

        foreach (GameObject fungi in fungiPieces)
        {
            fungi.SetActive(false);
        }

        CheckForActiveFungi();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckForActiveFungi()
    {
        for (int i = 0; i < fungiPieces.Length; i++)
        {
            GameObject temp = fungiPieces[i];
            int randomIndex = UnityEngine.Random.Range(i, fungiPieces.Length);
            fungiPieces[i] = fungiPieces[randomIndex];
            fungiPieces[randomIndex] = temp;
        }

        numberOfFungiToSpawn = (int)Math.Round(fungiData.territorySpread * 2.5, 0);


        if (numberOfFungiToSpawn < fungiPieces.Length - 1)
        {
            for (int i = 0; i < numberOfFungiToSpawn; i++)
            {
                fungiPieces[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < 700; i++)
            {
                fungiPieces[i].SetActive(true);
            }
        }

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

        for (int i = 0; i < UnityEngine.Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[0], scoreIcons[0].transform.parent);
        }
        for (int i = 0; i < UnityEngine.Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[1], scoreIcons[1].transform.parent);
        }
        for (int i = 0; i < UnityEngine.Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[2], scoreIcons[2].transform.parent);
        }
        for (int i = 0; i < UnityEngine.Random.Range(1, 10); i++)
        {
            Instantiate(scoreIcons[3], scoreIcons[3].transform.parent);
        }
        winButton.SetActive(false);
    }


}
