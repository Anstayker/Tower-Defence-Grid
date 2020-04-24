using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    #pragma warning disable 0649
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isPathfinding = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void Start() {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
    }

    private void Pathfind() {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isPathfinding) {
            Waypoint searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            if (searchCenter == endWaypoint) {
                isPathfinding = false;
            }
            ExploreNeighbours(searchCenter);
        }
    }

    private void ExploreNeighbours(Waypoint from) {
        if (!isPathfinding) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighbourCoordinates = direction + from.GetGridPos();
            try {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch { }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates) {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.isExplored) {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);          
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Skipping Overlapping.block " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.grey);
            }
        }
    }
}
