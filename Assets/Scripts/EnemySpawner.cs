using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] EnemyMovement enemy;
    [SerializeField] float spawnLapse = 2.0f;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnSound;

    private int waveNumber = 0;

    private void Start() {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {
        while(true) {
            EnemyMovement newEnemy = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(spawnSound);
            waveNumber++;
            scoreText.text = ("Score: " + waveNumber);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(spawnLapse);
        }
    }
}
