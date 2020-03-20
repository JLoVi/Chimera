using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
//        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //get vector direction with substraction
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //normalise results in always the same speed

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {

    //    if (waypointIndex >= Waypoints.points.Length - 1)
   //     {
      //      Destroy(gameObject);
      //      return;
     //   }

      //  waypointIndex++;
    //    target = Waypoints.points[waypointIndex];
    }
}
