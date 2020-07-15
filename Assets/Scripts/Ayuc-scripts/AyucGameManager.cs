using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyucGameManager : MonoBehaviour
{

    public delegate void ChangeTarget();
    public static event ChangeTarget OnTargetChange;

    public AyucData ayucData;
    public AcpData acpData;
    public AyucNavAgentStore ayucAgentStore;

    public GameEvent onSpawnAgents;
    private bool worldEndUtility;
    public GameObject[] interactiveUIElements;
  //  public int agentCount;
    public Transform spawnPosition;

    public int numberOfAgents;
    public static int birthrate;

    public Text birthrateText;
    public Text remainingTimeText;

    public GameObject[] responseUI;

    public CommandContainer commandContainer;
    public Text commandText;

    public CommandResponse currentCommand;
    public int currentResponseIndex;
    public Text[] responseButtonTexts;

    public static AyucGameManager instance;

    private void Awake()
    {
        instance = this;
        worldEndUtility = false;
    }
    void Start()
    {
        Cursor.visible = true;

      
        if (acpData.socialScore < -500)
        {
            ayucData.numberOfUnbornChildren = 1;
        }
        if(acpData.socialScore > -500 && acpData.socialScore < -100)
        {
            ayucData.numberOfUnbornChildren = Random.Range(1,5);
        }
        if (acpData.socialScore > -100 && acpData.socialScore < 0)
        {
            ayucData.numberOfUnbornChildren = Random.Range(3, 10);
        }
        if (acpData.socialScore >0 && acpData.socialScore < 100)
        {
            ayucData.numberOfUnbornChildren = Random.Range(10, 20);
        }

        if (acpData.socialScore > 100 && acpData.socialScore < 500)
        {
            ayucData.numberOfUnbornChildren = Random.Range(20, 50);
        }
        if (acpData.socialScore >  500)
        {
            ayucData.numberOfUnbornChildren = Random.Range(50, 100);
        }


        SetResponseUI(false);

        if (ayucData.worldEnd)
        {
            StopAllCoroutines();
            commandText.gameObject.SetActive(true);
            commandText.text = "YOU RAN OUT OF TIME" + '\n' + "THIS IS THE END OF THE WORLD";
            foreach (GameObject obj in interactiveUIElements)
            {
                obj.SetActive(false);
            }

        }

        else { 
        StartCoroutine(DisplayRandomCommand());
        }
    }

    public void Update()
    {
        if (worldEndUtility)
        {
            worldEndUtility = false;
            StopAllCoroutines();
            commandText.gameObject.SetActive(true);
            commandText.text = "YOU RAN OUT OF TIME" + '\n' + "THIS IS THE END OF THE WORLD";
            foreach (GameObject obj in interactiveUIElements)
            {
                obj.SetActive(false);
            }

        }
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
        int randomCommandResponseIndex = Random.Range(0, commandContainer.commands.Count);
        currentCommand = commandContainer.commands[randomCommandResponseIndex];
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
        for (int i = 0; i < ayucData.numberOfUnbornChildren; i++)
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
        if (numberOfAgents == 0)
        {
            ayucData.worldEnd = true;
            worldEndUtility = true;
        }

    }
}
