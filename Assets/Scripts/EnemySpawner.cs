using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] EnemyMovement enemy;
    [SerializeField] float spawnLapse = 2.0f;

    private void Start() {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {
        while(true) {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnLapse);
        }
    }
}
