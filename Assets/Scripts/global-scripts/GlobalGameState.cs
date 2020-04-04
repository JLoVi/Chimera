﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GlobalGameState : MonoBehaviour
{
    [SerializeField]
    private int activeScene;

    [SerializeField]
    private GameEvent OnSceneChanged;

    [SerializeField]
    private ActiveSceneData activeSceneData;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeScene = 1;
            OnSceneChanged.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeScene = 2;
            OnSceneChanged.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeScene = 3;
            OnSceneChanged.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeScene = 4;
            OnSceneChanged.Raise();
        }

        //0 or 5 is default scene

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activeScene = 0;
            OnSceneChanged.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            activeScene = 0;
            OnSceneChanged.Raise();
        }
    }

    public void UpdateScene()
    {
        switch (activeScene)
        {
            case 1:
                if (!activeSceneData.acpActive)
                {
                    SceneManager.LoadScene("01-acp", LoadSceneMode.Additive);
                    activeSceneData.acpActive = true;
                }

                if (activeSceneData.fungiActive)
                {
                    SceneManager.UnloadSceneAsync("02-fungi");
                    activeSceneData.fungiActive = false;
                }
                if (activeSceneData.ayucActive)
                {
                    SceneManager.UnloadSceneAsync("03-ayuc");
                    activeSceneData.ayucActive = false;
                }
                if (activeSceneData.rockActive)
                {
                    SceneManager.UnloadSceneAsync("04-rock");
                    activeSceneData.rockActive = false;
                }
                break;
            case 2:
                if (!activeSceneData.fungiActive)
                {
                    SceneManager.LoadScene("02-fungi", LoadSceneMode.Additive);
                    activeSceneData.fungiActive = true;
                }

                if (activeSceneData.acpActive)
                {
                    SceneManager.UnloadSceneAsync("01-acp");
                    activeSceneData.acpActive = false;
                }
                if (activeSceneData.ayucActive)
                {
                    SceneManager.UnloadSceneAsync("03-ayuc");
                    activeSceneData.ayucActive = false;
                }
                if (activeSceneData.rockActive)
                {
                    SceneManager.UnloadSceneAsync("04-rock");
                    activeSceneData.rockActive = false;
                }

                break;
            case 3:
                if (!activeSceneData.ayucActive)
                {
                    SceneManager.LoadScene("03-ayuc", LoadSceneMode.Additive);
                    activeSceneData.ayucActive = true;
                }

                if (activeSceneData.fungiActive)
                {
                    SceneManager.UnloadSceneAsync("02-fungi");
                    activeSceneData.fungiActive = false;
                }
                if (activeSceneData.acpActive)
                {
                    SceneManager.UnloadSceneAsync("01-acp");
                    activeSceneData.acpActive = false;
                }
                if (activeSceneData.rockActive)
                {
                    SceneManager.UnloadSceneAsync("04-rock");
                    activeSceneData.rockActive = false;
                }

                break;
            case 4:
                if (!activeSceneData.rockActive)
                {
                    SceneManager.LoadScene("04-rock", LoadSceneMode.Additive);
                    activeSceneData.rockActive = true;
                }

                if (activeSceneData.fungiActive)
                {
                    SceneManager.UnloadSceneAsync("02-fungi");
                    activeSceneData.fungiActive = false;
                }
                if (activeSceneData.ayucActive)
                {
                    SceneManager.UnloadSceneAsync("03-ayuc");
                    activeSceneData.ayucActive = false;
                }
                if (activeSceneData.acpActive)
                {
                    SceneManager.UnloadSceneAsync("01-acp");
                    activeSceneData.acpActive = false;
                }

                break;
            case 0:
                SceneManager.LoadScene("00-base-all", LoadSceneMode.Single);
                activeSceneData.acpActive = false;
                activeSceneData.fungiActive = false;
                activeSceneData.ayucActive = false;
                activeSceneData.rockActive = false;
                break;
            default:
                SceneManager.LoadScene("00-base-all", LoadSceneMode.Single);
                activeSceneData.acpActive = false;
                activeSceneData.fungiActive = false;
                activeSceneData.ayucActive = false;
                activeSceneData.rockActive = false;
                break;

        }
    }
}
