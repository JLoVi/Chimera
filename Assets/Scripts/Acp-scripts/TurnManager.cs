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

    public Text capitalText;
    public Text SocialScoreText;
    public Text EnvScoreText;
    public Text EconomucScoreText;



    void Start()
    {
        GlobalDataStorage.seasonCount = 1;
        GlobalDataStorage.seasonTimerValue = StartTimerValue;
        GameEventsGlobal.currentGlobalEvent.onCapitalUpdated += OnCapitalUpdated;

        capitalText.text = "Capital: " + GlobalDataStorage.capital.ToString();
        GameEventsGlobal.currentGlobalEvent.onSeasonBegin += OnSeasonBegin;
        GameEventsGlobal.currentGlobalEvent.onSeasonEnd += OnSeasonEnd;

    }

    public void StartSeason()
    {
        
        StartCoroutine(StartSeasonCounter());

    }

    public IEnumerator StartSeasonCounter()
    {
        GameEventsGlobal.currentGlobalEvent.SeasonBegin();
        while (GlobalDataStorage.seasonTimerValue >= 0.0f)
        {
            //if (!isPaused)
            //{
            GlobalDataStorage.seasonTimerValue -= Time.deltaTime;
            // }

            foreach(BuildingSlot building in GlobalDataStorage.buildings)
            {
               GlobalDataStorage.capital = GlobalDataStorage.capital += building.impactCapital * 0.1f;

                capitalText.text = "Total Capital Revenues: " + Mathf.RoundToInt(GlobalDataStorage.capital);
            }

            TimeTilTurnText.text = "Time until next turn: " + Mathf.RoundToInt(GlobalDataStorage.seasonTimerValue);

            //  yield return new WaitForEndOfFrame ();
            yield return null;
            
        }
        GameEventsGlobal.currentGlobalEvent.SeasonEnd();
       // GameEventsGlobal.currentGlobalEvent.onSeasonBegin -= OnSeasonBegin;
    }


    public void OnSeasonBegin()
    {
        Debug.Log("Start Season");
        GlobalDataStorage.inSeason = true;
        GlobalDataStorage.seasonCount++;
        startSeasonButton.SetActive(false);
        SeasonCountText.text = "Season / Turn: " + GlobalDataStorage.seasonCount;
        TimeTilTurnText.text = "Time until next turn: " + GlobalDataStorage.seasonTimerValue;
    }

    public void OnSeasonEnd()
    {
        Debug.Log("End Season");
        GlobalDataStorage.seasonTimerValue = StartTimerValue;
        startSeasonButton.SetActive(true);

    }

    private void OnCapitalUpdated()
    {

        capitalText.text = "Total Capital Revenues: " + Mathf.RoundToInt(GlobalDataStorage.capital);

    }


}
