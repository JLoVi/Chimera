using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buildingPieces;

    public GameObject fungi;

    public BuildingSlot parentSlot;

    public void Awake()
    {
        fungi.SetActive(false);
    }
    public void Start()
    {

        



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
       

        yield return new WaitForSeconds(20f);
        StartCoroutine(ActivatePiece(false));
    }

}
