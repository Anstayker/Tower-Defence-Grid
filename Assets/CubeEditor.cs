using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    [SerializeField][Range(1.0f, 20.0f)] float gridSize = 10.0f;

    TextMesh textMesh;

    private void Update() {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x/gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z/gridSize) * gridSize;

        transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);
    
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPosition.x/gridSize + ", " + snapPosition.z/gridSize;
    }

}
