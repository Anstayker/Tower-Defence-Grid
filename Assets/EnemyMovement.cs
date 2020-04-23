using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

    private void Start() {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path) {
            print("Visiting waypoint: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
        print("Ending patrol");
    }
}
