using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [Tooltip("In Unity units")][SerializeField] float attackRange = 30.0f;
    [SerializeField] float attackRate = 2.0f;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] Transform targetEnemy;

    ParticleSystem.EmissionModule emissionModule;

    private void Start() {
        emissionModule = projectileParticle.emission;
        
    }

    private void Update() {
        emissionModule.rateOverTime = attackRate;
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
            //Search for another enemy
        }
    }
}
