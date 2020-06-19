using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buildingPieces;

    public GameObject fungi;

    public bool fungiPresence;
    private bool canAnimate;

    public BuildingSlot parentSlot;

    public enum State { Decay, Recovery, Repaired, Demolished}

    public void Start()
    {
        parentSlot = AcpDataHandler.selectedBuildingSlot;
        fungi.SetActive(false);
        fungiPresence = false;
        canAnimate = true;

        foreach (Transform piece in transform)
        {
            buildingPieces.Add(piece.gameObject);
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
    }

    public void Update()
    {
        if(fungiPresence && canAnimate)
        {
            StartCoroutine(StartFungiAttack());
        }
    }

    public IEnumerator ActivatePiece(bool state)
    {
        foreach (GameObject piece in buildingPieces)
        {
            yield return new WaitForSeconds(0.1f);
            piece.SetActive(state);
        }
    }

    public IEnumerator StartFungiAttack()
    {
        canAnimate = false;
        fungi.SetActive(true);
        yield return new WaitForSeconds(20f);
        StartCoroutine(ActivatePiece(false));
    }

   

}
