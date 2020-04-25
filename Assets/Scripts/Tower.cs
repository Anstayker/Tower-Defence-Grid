using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [Tooltip("In Unity units")][SerializeField] float attackRange = 30.0f;
    [SerializeField] float attackRate = 2.0f;
    [SerializeField] ParticleSystem projectileParticle;

    Transform targetEnemy;
    ParticleSystem.EmissionModule emissionModule;

    private void Start() {
        emissionModule = projectileParticle.emission;
        
    }

    private void Update() {
        emissionModule.rateOverTime = attackRate;
        // Search here for the closest enemy
        SearchTargetEnemy();
        ShotAtEnemy();
    }

    private void ShotAtEnemy() {
        if (targetEnemy != null) {
            float distanceToEnemy = Vector3.Distance(
                        targetEnemy.transform.position, 
                        gameObject.transform.position);
            if (distanceToEnemy <= attackRange) {
                objectToPan.transform.LookAt(targetEnemy);
                emissionModule.enabled = true;
            } else {
                            
                emissionModule.enabled = false;
            }
        } else {
            emissionModule.enabled = false;
        }

    }

    private void SearchTargetEnemy() {
        EnemyCollisionHandler[] sceneEnemies = FindObjectsOfType<EnemyCollisionHandler>();
        if (sceneEnemies.Length == 0) {return;}

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyCollisionHandler testEnemy in sceneEnemies) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform enemy1, Transform enemy2) {
        float distanceToEnemy1 = Vector3.Distance(
                enemy1.transform.position, 
                gameObject.transform.position);
        float distanceToEnemy2 = Vector3.Distance(
                enemy2.transform.position, 
                gameObject.transform.position);                        
        if (distanceToEnemy1 > distanceToEnemy2) {return enemy2;}
        else {return enemy1;}
    }
}
