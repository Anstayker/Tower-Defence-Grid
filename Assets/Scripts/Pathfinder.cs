﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    #pragma warning disable 0649
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isPathfinding = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath() {
        if (path.Count == 0) {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath() {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath() {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint) {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch() {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isPathfinding) {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            if (searchCenter == endWaypoint) { isPathfinding = false; }
            ExploreNeighbours();
        }
    }

    private void ExploreNeighbours() {
        if (!isPathfinding) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighbourCoordinates = direction + searchCenter.GetGridPos();
            if(grid.ContainsKey(neighbourCoordinates)) {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates) {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour)) {} 
        else {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;  
        }
    }

    private void ColorStartAndEnd()
    {
        // todo move out
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
