using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Spore : MonoBehaviour
{
    public Transform target;

    [Header ("Attributes")]

    public float range = 15f;
    public float fireRate = 6f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string friendTag = "spore";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public Text territoryText;
    public static float territoryPercentage;

    public bool shooting;

    public static Animator fungiAnimator;

    void Start()
    {
        territoryText = GameObject.Find("textterritory").GetComponent<Text>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        shooting = false;
       // territoryPercentage = 0;
        territoryText.text = "territory occupied: " + territoryPercentage + "%" ;

       fungiAnimator = GameObject.Find("fungi-territory-all").GetComponent<Animator>();
    }

    void UpdateTarget()
    {


        GameObject[] enemies = GameObject.FindGameObjectsWithTag(friendTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy > 0.5f)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void Update()
    {

       // Debug.Log(shooting);
        if (target == null)
            return;

        //target lock on

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        float territoryRounded = (float)Math.Round(territoryPercentage, 1);
        territoryText.text = "territory occupied: " + territoryRounded + "%";

        if (fireCountdown <= 3f)
        {

            if (!shooting)
            {
                IncreaseTerritory();
            }
            Shoot();
            fireCountdown = 1f / fireRate;
            
        }
    }

    void Shoot()
    {
        
        shooting = true;

        
        
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void IncreaseTerritory()
    {
        if (territoryPercentage < 100) { 
        territoryPercentage += UnityEngine.Random.Range(0.1f, 0.3f);
        float territoryRounded =  (float)Math.Round(territoryPercentage, 1);
        territoryText.text = "territory occupied: " + territoryRounded + "%";
            // shooting = false;
            StartCoroutine(PlayAnimInterval(0.2f, 5f));
        }


    }

    private IEnumerator PlayAnimInterval(float speed, float time)
    {
        fungiAnimator.speed = speed;
        yield return new WaitForSeconds(time);
        fungiAnimator.speed = 0;
    }

}
