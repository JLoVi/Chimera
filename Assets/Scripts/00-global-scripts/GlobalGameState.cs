using System.Collections;
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

   
    public ActiveSceneData activeSceneData;
    public Camera mainCam;

    [SerializeField]
    private GameObject acpAssets;

    public static GlobalGameState instance;

    public void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Q) )
        {
            Application.Quit();
        }

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
                mainCam.gameObject.SetActive(false);
           //     EnableACPRuntimeAssetProperties();
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
                mainCam.gameObject.SetActive(false);
             //   DisableACPRuntimeAssetProperties();
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
                mainCam.gameObject.SetActive(false);
             //   DisableACPRuntimeAssetProperties();
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
                mainCam.gameObject.SetActive(false);
              //  DisableACPRuntimeAssetProperties();
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
                mainCam.gameObject.SetActive(true);
                SceneManager.LoadScene("00-base-all", LoadSceneMode.Single);
                activeSceneData.acpActive = false;
                activeSceneData.fungiActive = false;
                activeSceneData.ayucActive = false;
                activeSceneData.rockActive = false;
              //  DisableACPRuntimeAssetProperties();
                break;

            default:
                mainCam.gameObject.SetActive(true);
                SceneManager.LoadScene("00-base-all", LoadSceneMode.Single);
                activeSceneData.acpActive = false;
                activeSceneData.fungiActive = false;
                activeSceneData.ayucActive = false;
                activeSceneData.rockActive = false;
             //   DisableACPRuntimeAssetProperties();
                break;
        }
    }

   /* public void DisableACPRuntimeAssetProperties()
    {
        if (acpAssets != null)
        {
            foreach (Transform child in acpAssets.transform)
            {

                if (child.GetComponent<SlotClickArea>() != null)
                {
                    child.GetComponent<SlotClickArea>().enabled = false;
                }
                if (child.GetComponent<SlotController>() != null) child.GetComponent<SlotController>().enabled = false;
            }
        }
        else
        {
            Debug.Log("Global Game Maanger: no ACP runtime assets to disable");
        }

    }

    public void EnableACPRuntimeAssetProperties()
    {
        if (acpAssets != null)
        {
            foreach (Transform child in acpAssets.transform)
            {
                if (child.GetComponent<SlotClickArea>() != null)
                {
                    child.GetComponent<SlotClickArea>().enabled = false;
                }
                if (child.GetComponent<SlotController>() != null) child.GetComponent<SlotController>().enabled = false;
            }
        }
        else
        {
            Debug.Log("Global Game Maanger: no ACP runtime assets to disable");
        }
    }*/
}
