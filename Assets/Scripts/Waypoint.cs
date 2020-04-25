using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [HideInInspector] public bool isExplored = false;
    [HideInInspector] public Waypoint exploredFrom;
    public bool isPlaceable = true;
    [Tooltip("Tower Prefab")][SerializeField] Tower tower;

    const int gridSize = 10;
    Vector2Int gridPos;

    public int GetGridSize() {
        return gridSize;
    }

    public Vector2Int GetGridPos() {
        return new Vector2Int(        
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && isPlaceable) {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
   

}
