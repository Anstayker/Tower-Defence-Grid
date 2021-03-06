﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Tooltip("Seconds between block")][SerializeField] float velocity = 1.0f;

    private void Start() {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            waypoint.SetTopColor(Color.cyan);   
            yield return new WaitForSeconds(velocity);
        }
        EnemyCollisionHandler enemyCollisionHandler = gameObject.GetComponent<EnemyCollisionHandler>();
        enemyCollisionHandler.selfDestruct();
        FindObjectOfType<PlayerStats>().loseLifePoints(enemyCollisionHandler.damage);
    }
}
