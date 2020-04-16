using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{

    public GameObject startSeasonButton;

    public float StartTimerValue;
    //UI
    public Text TimeTilTurnText;
    public Text SeasonCountText;

   // public Text capitalText;
    public Text SocialScoreText;
    public Text EnvScoreText;
    public Text EconomucScoreText;

    public AcpData acpData;

    [SerializeField] private GameEvent OnCapitalUpdated;


    void Start()
    {
        AcpDataHandler.seasonCount = 1;
        AcpDataHandler.seasonTimerValue = StartTimerValue;
        OnCapitalUpdated.Raise();
        GameEventsTurns.currentSeasonEvent.onSeasonBegin += OnSeasonBegin;
        GameEventsTurns.currentSeasonEvent.onSeasonEnd += OnSeasonEnd;

    }

    public void StartSeason()
    {

        StartCoroutine(StartSeasonCounter());

    }

    public IEnumerator StartSeasonCounter()
    {
        GameEventsTurns.currentSeasonEvent.SeasonBegin();
        while (AcpDataHandler.seasonTimerValue >= 0.0f)
        {
            //if (!isPaused)
            //{
            AcpDataHandler.seasonTimerValue -= Time.deltaTime;
            // }

            /*  foreach (BuildingSlot buildingSlot in AcpDataHandler.buildingSlots)
            {
                acpData.capital = acpData.capital += building.impactCapital * 0.1f;
                OnCapitalUpdated.Raise();
                //capitalText.text = "Total Capital Revenues: " + Mathf.RoundToInt(acpData.capital);

            }*/

            TimeTilTurnText.text = "Time until next turn: " + Mathf.RoundToInt(AcpDataHandler.seasonTimerValue);

            //  yield return new WaitForEndOfFrame ();
            yield return null;

        }
        GameEventsTurns.currentSeasonEvent.SeasonEnd();
        // GameEventsGlobal.currentGlobalEvent.onSeasonBegin -= OnSeasonBegin;
    }


    public void OnSeasonBegin()
    {
        Debug.Log("Start Season");
        AcpDataHandler.inSeason = true;
        AcpDataHandler.seasonCount++;
        startSeasonButton.SetActive(false);
        SeasonCountText.text = "Season / Turn: " + AcpDataHandler.seasonCount;
        TimeTilTurnText.text = "Time until next turn: " + AcpDataHandler.seasonTimerValue;
    }

    public void OnSeasonEnd()
    {
        Debug.Log("End Season");
        AcpDataHandler.seasonTimerValue = StartTimerValue;
        startSeasonButton.SetActive(true);

    }

   


}
