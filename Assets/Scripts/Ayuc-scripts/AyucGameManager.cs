using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyucGameManager : MonoBehaviour
{

    public delegate void ChangeTarget();
    public static event ChangeTarget OnTargetChange;

    public AyucData ayucData;
    public AyucNavAgentStore ayucAgentStore;

    public GameEvent onSpawnAgents;

    public static CommandResponse currentCommandResponse;

    public int agentCount;
    public Transform spawnPosition;

    public static int numberOfAgents;
    public static int birthrate;

    public Text birthrateText;
    public Text remainingTimeText;

    public enum Response
    {
        yes = 0,
        no = 1,
        maybe = 2,
        word = 3
    };

    public Response currentResponse;

    public Text commandText;

    public GameObject responseUI;

    void Start()
    {
        Cursor.visible = true;
        responseUI.SetActive(false);
        StartCoroutine(DisplayCommand());
    }

    public void ClickAction(int response)
    {
        currentResponse = (Response)response;
        Debug.Log(currentResponse);
        if (OnTargetChange != null)
        {
            OnTargetChange();
        }
        responseUI.SetActive(false);

        StartCoroutine(DisplayCommand());

        if (currentResponse == Response.yes)
        {
            currentCommandResponse.response.Raise();
            onSpawnAgents.Raise();
        }
        if (currentResponse == Response.no)
        {
            return;
        }
    }

    public IEnumerator DisplayCommand()
    {
        yield return new WaitForSeconds(5f);
        responseUI.SetActive(true);
        currentCommandResponse = ayucData.commandResponses[Random.Range(0, ayucData.commandResponses.Count)];
        commandText.text = currentCommandResponse.command;
        
    }

    public void SpawnAgents()
    {
        StartCoroutine(InstantiateAgentsByCount());

    }


    public IEnumerator InstantiateAgentsByCount()
    {
        for (int i = 0; i < agentCount; i++)
        {
            Instantiate(ayucAgentStore.agentMeshes[0], spawnPosition.position, Quaternion.identity, AyucDataHandler.ayucRuntimeAssetParent.transform);
            numberOfAgents++;
            OnUpdateBirthRate();
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void OnUpdateBirthRate()
    {
        birthrateText.text = "Birth Rate: " + birthrate;
        remainingTimeText.text = "Remaining Time: " + numberOfAgents;

    }
}
