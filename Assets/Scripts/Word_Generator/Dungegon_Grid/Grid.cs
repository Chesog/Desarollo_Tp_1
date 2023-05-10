using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid : MonoBehaviour
{
    [Serializable]
    public struct NodeGrid
    {
        public List<Node2D> nodes;
    }
    public  List<NodeGrid> gridOfNodes;
    public List<Node2D> listita;
    public Node2D[,,] grid;
    public int sizeX = 10;
    public int sizeY = 1;
    public int sizeZ = 10;
    public bool showGrid;
    public float pointsInGridSize = 0.1f;
    public static float delta = 1f;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Node2D[sizeX, sizeY, sizeZ];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int z = 0; z < grid.GetLength(2); z++)
                {
                    grid[x, y, z] = new Node2D(x, y, z) * delta;
                    Debug.Log("Node2D pos x" + x + " " + y + " " + z);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        { return; }

        Gizmos.color = Color.black;

        if (!showGrid)
            return;

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int z = 0; z < grid.GetLength(2); z++)
                {
                    Gizmos.DrawWireSphere(grid[x, y, z].pos, pointsInGridSize);
                }
            }
        }
    }
}
