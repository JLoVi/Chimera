using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buildingPieces;

    public GameObject fungi;

    private Color[] slotColors;

    public SlotController parentSlot;

    public void Awake()
    {
        fungi.SetActive(false);
    }
    public void Start()
    {


        foreach (Transform piece in transform)
        {
            buildingPieces.Add(piece.gameObject);
            piece.GetComponent<Renderer>().material.color = GameManagerAcp.instance.acpData.buildingColor;
            piece.gameObject.SetActive(false);

        }
        for (int i = 0; i < buildingPieces.Count; i++)
        {
            GameObject temp = buildingPieces[i];
            int randomIndex = Random.Range(i, buildingPieces.Count);
            buildingPieces[i] = buildingPieces[randomIndex];
            buildingPieces[randomIndex] = temp;
        }
        StartCoroutine(ActivatePiece(true));

        GameEventsBuildingSlots.currentBuildingSlotEvent.onRecoverFromAttack += OnFungiRecover;
    }

    public void Update()
    {

    }

    public IEnumerator ActivatePiece(bool state)
    {
        foreach (GameObject piece in buildingPieces)
        {
            yield return new WaitForSeconds(0.1f);
            piece.SetActive(state);
        }
    }

    public void OnFungiAttack()
    {

        fungi.SetActive(true);
     //   Debug.Log(fungi.activeSelf);
        StartCoroutine(StartFungiAttack());

    }
    public IEnumerator StartFungiAttack()
    {
        parentSlot.buildingSlot.slotCondition = Condition.Damaged;

        yield return new WaitForSeconds(GameManagerAcp.instance.acpData.buildingResistanceTime);
     
        parentSlot.buildingSlot.slotCondition = Condition.Destroyed;
        StartCoroutine(ActivatePiece(false));

        yield return new WaitForSeconds(GameManagerAcp.instance.acpData.buildingResistanceTime*2);
        parentSlot.RemoveSlotFromDatabase();

    }

    public void OnFungiRecover(LocationOnMap location, bool fungiactive)
    {
        if (parentSlot.buildingSlot.location!=null && parentSlot.buildingSlot.location == location && parentSlot.fungiActive)
        {
            StopAllCoroutines();
            parentSlot.buildingSlot.slotCondition = Condition.Recovery;
            StartCoroutine(ActivatePiece(true));
            fungi.SetActive(false);
            


        }
    }

}
