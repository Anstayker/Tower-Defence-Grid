using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO mover este Script al padre
// Se deberia crear un Box Collider al hijo

[RequireComponent(typeof(BoxCollider))]
public class EnemyCollisionHandler : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject deathFX;

    private void Start() {
        AddBoxCollider();
    }

    private void AddBoxCollider() {
        Collider newCollider = gameObject.AddComponent<BoxCollider>();
        newCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        hitPoints--;
        if (hitPoints <= 0) {
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(parent);
        }
    }
}
