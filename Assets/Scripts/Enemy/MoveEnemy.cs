using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{    
    private int waypointIndex = 0;
    private float lastWaypointSwitchTime;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
        enemy = gameObject.GetComponentInChildren<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPosition = Waypoints.points[waypointIndex + 1].transform.position;        
        gameObject.transform.position = Vector2.MoveTowards(transform.position, endPosition, Time.deltaTime * enemy.CurrentMoveSpeed);

        if (gameObject.transform.position.Equals(endPosition)) {
            if (waypointIndex < Waypoints.points.Length - 2) {
                waypointIndex ++ ;
                lastWaypointSwitchTime = Time.time;
            } else {
                Destroy(gameObject);
            }
        }
    }
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position, 
            Waypoints.points [waypointIndex + 1].transform.position);
        for (int i = waypointIndex + 1; i < Waypoints.points.Length - 1; i++)
        {
            Vector3 startPosition = Waypoints.points [i].transform.position;
            Vector3 endPosition = Waypoints.points [i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
