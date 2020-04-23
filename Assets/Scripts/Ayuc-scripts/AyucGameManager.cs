using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyucGameManager : MonoBehaviour
{

    public delegate void ChangeTarget();
    public static event ChangeTarget OnTargetChange;

    public AyucData ayucData;

    public static CommandResponse currentCommandResponse;

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
        // Debug.Log(currentResponse);
        if (OnTargetChange != null)
        {
            OnTargetChange();
        }
        responseUI.SetActive(false);

        StartCoroutine(DisplayCommand());

        if (currentResponse == Response.yes)
        {
            currentCommandResponse.response.Raise();
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
}
