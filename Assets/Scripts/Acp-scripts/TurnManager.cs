using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{

    public GameObject startSeasonButton;

   // public float StartTimerValue;
    //UI
    public Text TimeTilTurnText;
    public Text SeasonCountText;

    public Text revenuesText;
    public Text capitalText;

    public AcpData acpData;

    [SerializeField] private GameEvent OnCapitalUpdated;


    void Start()
    {
        AcpDataHandler.seasonCount = 1;
        AcpDataHandler.seasonTimerValue = acpData.seasonLength;
        OnCapitalUpdated.Raise();
        GameEventsTurns.currentSeasonEvent.onSeasonBegin += OnSeasonBegin;
        GameEventsTurns.currentSeasonEvent.onSeasonEnd += OnSeasonEnd;
        revenuesText.text = "Start season to calculate revenues";
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
            AcpDataHandler.seasonTimerValue -= Time.deltaTime;
        
            TimeTilTurnText.text = "Time until next turn: " + Mathf.RoundToInt(AcpDataHandler.seasonTimerValue);

            
            CalculateRevenues();

            yield return null;

        }
        GameEventsTurns.currentSeasonEvent.SeasonEnd();
    }

    public void CalculateRevenues()
    {
        AcpDataHandler.revenues += acpData.economicGrowth / 10;
        revenuesText.text = "Seasonal Revenues: " + AcpDataHandler.revenues;
        acpData.capital += acpData.economicGrowth / 10;
        
        capitalText.text = "TOTAL CAPITTAL REVENUES: " + acpData.capital;
    }

    public void OnSeasonBegin()
    {
        Debug.Log("Start Season");
        AcpDataHandler.revenues = 0;
        AcpDataHandler.inSeason = true;
        AcpDataHandler.seasonCount++;
        startSeasonButton.SetActive(false);
        SeasonCountText.text = "Season / Turn: " + AcpDataHandler.seasonCount;
        TimeTilTurnText.text = "Time until next turn: " + AcpDataHandler.seasonTimerValue;
    }

    public void OnSeasonEnd()
    {
        Debug.Log("End Season");
        AcpDataHandler.seasonTimerValue = acpData.seasonLength;
        startSeasonButton.SetActive(true);
        AcpDataHandler.instance.CalculateTargetCapital();
        GameManagerAcp.instance.UpdateCapitalTargetText();

    }

}
