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
                rend.material.color = hoverColor;

            }
        }
    }

    void OnMouseExit()
    {
        if (GlobalGameState.instance.activeSceneData.rockActive)
        {
            rend.material.color = startColor;
        }
    }
}
