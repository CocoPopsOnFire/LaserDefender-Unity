using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    //config params
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    //static params
    int waypointIndex = 0;

	//unity methods
	void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}

	void Update () {
        if(waypointIndex <= waypoints.Count-1) {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if(transform.position == targetPosition) {
                waypointIndex++;
            }
        }
	}

}
