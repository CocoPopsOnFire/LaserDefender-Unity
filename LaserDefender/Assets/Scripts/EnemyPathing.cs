using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    //config params
    WaveConfig waveConfig;
    //static params
    int waypointIndex = 0;
    List<Transform> waypoints;


	//unity methods
	void Start () {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}

	void Update () {
        Move();
	}

  void Move(){
    if(waypointIndex <= waypoints.Count-1) {
        var targetPosition = waypoints[waypointIndex].transform.position;
        var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        if(transform.position == targetPosition) {
            waypointIndex++;
        }
    }
  }

  public void SetWaveConfig(WaveConfig newWaveConfig){
      waveConfig=newWaveConfig;
      //in tutorial the parameter is called waveConfig instead of newWaveConfig, so you would use this.waveConfig=waveConfig;
  }

}
