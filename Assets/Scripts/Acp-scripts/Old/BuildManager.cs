using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("more than one buildmanager in scene");
            return;
        }

        instance = this;
    }

    public GameObject buildingA;
    public GameObject buildingB;
    public GameObject buildingC;

    void Start()
    {
        turretToBuild = buildingC;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
