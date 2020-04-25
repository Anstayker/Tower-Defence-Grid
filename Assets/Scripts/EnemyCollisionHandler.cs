using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyCollisionHandler : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem deathFX;

    private void OnParticleCollision(GameObject other) {
        hitPoints--;
        if (hitPoints <= 0) {   
            killEnemy();
        } else {
            hitFX.Play();
        }
    }

    private void killEnemy() {
       Vector3 particlePoint = new Vector3(
            transform.position.x,
            transform.position.y + 5.0f,
            transform.position.z
        );

        Instantiate(deathFX, particlePoint, Quaternion.identity);
        Destroy(gameObject);
    }
}
