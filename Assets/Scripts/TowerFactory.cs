using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [Tooltip("Tower Prefab")][SerializeField] Tower tower;
    public int towerLimit = 3;
    [SerializeField] GameObject towerParent;

    Queue<Tower> towersInGame = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint) {
        if (towerLimit > towersInGame.Count) {
            InstateNewTower(baseWaypoint);
        }
        else {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstateNewTower(Waypoint newBaseWaypoint) {
        Tower newTower = Instantiate(tower, newBaseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform;
        newTower.baseWaypoint = newBaseWaypoint;
        newBaseWaypoint.isPlaceable = false;
        towersInGame.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint) {
        Tower oldTower = towersInGame.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        newBaseWaypoint.isPlaceable = false;
        towersInGame.Enqueue(oldTower);
    }
}
