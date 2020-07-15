using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundClickArea : MonoBehaviour
{
    public int id;
    public Color hoverColor;
    private Renderer rend;
    public Color startColor;
    public AudioSource audioSource;

    private void OnEnable()
    {
        GameManagerRock.OnInitializeScene += Initialize;

    }
    private void OnDisable()
    {
        GameManagerRock.OnInitializeScene -= Initialize;
    }

    void Start()
    {

        Initialize();
        if (GetComponent<AudioSource>() != null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }


    public void Initialize()
    {
        if (GlobalGameState.instance.activeSceneData.rockActive)
        {

            rend = GetComponent<Renderer>();
            id = GetComponent<SoundController>().id;

            startColor = rend.material.color;
        }
    }


    private void OnMouseDown()
    {
        if (GlobalGameState.instance.activeSceneData.rockActive)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (GetComponent<AudioSource>() != null)
                {
                    audioSource.Play();
                    audioSource.pitch = Random.Range(0.2f, 1.9f);
                }
                GameEventsRock.currentRockEvent.RockPropMouseClick(id);

            }
        }
    }

    void OnMouseEnter()
    {


        if (GlobalGameState.instance.activeSceneData.rockActive)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {

                GameEventsRock.currentRockEvent.RockPropMouseHover(id);

                

                if (rend.material.color != null)
                    rend.material.color = hoverColor;

            }
        }
    }

    void OnMouseExit()
    {
        if (GlobalGameState.instance.activeSceneData.rockActive)
        {

           
            if (rend.material.color != null)
                rend.material.color = startColor;
        }
    }
}
