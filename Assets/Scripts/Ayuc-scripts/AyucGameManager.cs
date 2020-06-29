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

    public int agentCount;
    public Transform spawnPosition;

    public static int numberOfAgents;
    public static int birthrate;

    public Text birthrateText;
    public Text remainingTimeText;

    public GameObject[] responseUI;

    public CommandContainer commandContainer;
    public Text commandText;

    public CommandResponse currentCommand;
    public int currentResponseIndex;
    public Text[] responseButtonTexts;

    void Start()
    {
        Cursor.visible = true;
        SetResponseUI(false);
        StartCoroutine(DisplayRandomCommand());
    }

    public void SetResponseUI(bool state)
    {
        foreach (GameObject obj in responseUI)
        {
            obj.SetActive(state);
        }
    }

    public void ClickAction(int responseIndex)
    {
        currentResponseIndex = responseIndex;
        Debug.Log(currentResponseIndex);
        if (OnTargetChange != null)
        {
            OnTargetChange();
        }
        SetResponseUI(false);

        StartCoroutine(DisplayRandomCommand());


        currentCommand.response.Raise();
        onSpawnAgents.Raise();
    }

    public IEnumerator DisplayRandomCommand()
    {
        yield return new WaitForSeconds(1f);
        SetResponseUI(true);
        currentCommand = commandContainer.commands[Random.Range(0, commandContainer.commands.Count)];
        DisplayRandomResponses();
        commandText.text = currentCommand.command;

    }

    public void DisplayRandomResponses()
    {
        responseButtonTexts[0].text = commandContainer.sequenceOne[Random.Range(0, commandContainer.sequenceOne.Count)];
        responseButtonTexts[1].text = commandContainer.sequenceTwo[Random.Range(0, commandContainer.sequenceTwo.Count)];
        responseButtonTexts[2].text = commandContainer.sequenceThree[Random.Range(0, commandContainer.sequenceThree.Count)];
        responseButtonTexts[3].text = commandContainer.sequenceFour[Random.Range(0, commandContainer.sequenceFour.Count)];

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
