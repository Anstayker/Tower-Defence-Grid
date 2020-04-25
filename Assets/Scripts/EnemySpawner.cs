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
            EnemyMovement newEnemy = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(spawnLapse);
        }
    }
}
