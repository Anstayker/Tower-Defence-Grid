using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    private void Update() {
        objectToPan.transform.LookAt(targetEnemy);
    }
}
