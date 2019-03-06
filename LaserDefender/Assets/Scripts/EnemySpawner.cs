using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;


	// Use this for initialization
	void Start () {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
	}

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave) {

        for(int enemyCount = 0; enemyCount < currentWave.GetEnemyCount(); enemyCount++) {
            Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoints()[enemyCount].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}
