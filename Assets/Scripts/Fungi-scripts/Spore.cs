using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spore : MonoBehaviour
{

    public Transform target;

    public float range = 15f;

    public string friendTag = "spore";

    public Transform partToRotate;
    private float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireSpeed = 0.05f;

    private bool shooting;

    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("expand");
        shooting = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (!shooting && fireSpeed < 1)
        {
            StartCoroutine(CreateConnection(fireSpeed));

        }
        if (fireSpeed >= 1)
        {
            StartCoroutine(Shrink());
        }
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, gameObject.transform);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public IEnumerator CreateConnection(float fireRate)
    {
        shooting = true;
        yield return new WaitForSeconds(fireRate);
        fireSpeed += 0.02f;
        Shoot();
        shooting = false;
    }

    public IEnumerator Shrink()
    {
        animator.SetTrigger("shrink");
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
