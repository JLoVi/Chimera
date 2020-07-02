using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public int id;

    private void OnEnable()
    {
        GameManagerRock.OnInitializeScene += Initialize;

    }
    private void OnDisable()
    {
        GameManagerRock.OnInitializeScene -= Initialize;
    }


    private void Awake()
    {

    }

    private void Start()
    {

        Initialize();
    }



    public void Initialize()
    {
        if (GlobalGameState.instance.activeSceneData.rockActive)
        {
            GameManagerRock.instance.soundControllers.Add(this);
            id = GameManagerRock.instance.soundControllers.Count();

            GameEventsRock.currentRockEvent.onRockPropMouseHover += OnRockPropHover;
            GameEventsRock.currentRockEvent.onRockPropMouseClick += OnRockPropClick;
        }
    }



    private void OnRockPropHover(int id)
    {
        if (id == this.id)
        {
            Debug.Log("hover");
        }
    }

    private void OnRockPropClick(int id)
    {
        if (id == this.id)
        {

            Debug.Log("click");
        }
    }
}
