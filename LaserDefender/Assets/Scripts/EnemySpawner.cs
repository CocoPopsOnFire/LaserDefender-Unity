using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    [SerializeField] bool looping = false;


	// Use this for initialization
	IEnumerator Start () {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while(looping);
	}

    private IEnumerator SpawnAllWaves() {
        for(int index=startingWave;index<waveConfigs.Count;index++) {
            var currentWave = waveConfigs[index];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave) {

        for(int enemyCount = 0; enemyCount < currentWave.GetEnemyCount(); enemyCount++) {
            var newEnemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}
