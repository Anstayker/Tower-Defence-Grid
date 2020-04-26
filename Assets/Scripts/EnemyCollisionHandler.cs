using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyCollisionHandler : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    public int damage = 1;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem goalFX;

    public void selfDestruct() {
        killEnemy(goalFX);
    }

    private void OnParticleCollision(GameObject other) {
        hitPoints--;
        if (hitPoints <= 0) {   
            killEnemy(deathFX);
        } else {
            hitFX.Play();
        }
    }

    private void killEnemy(ParticleSystem destructionFX) {
       Vector3 particlePoint = new Vector3 (
            transform.position.x,
            transform.position.y + 5.0f,
            transform.position.z
        );

        ParticleSystem enemyExplosion = Instantiate(destructionFX, particlePoint, Quaternion.identity);
        Destroy(enemyExplosion.gameObject, enemyExplosion.main.duration);
        Destroy(gameObject);
    }
}
