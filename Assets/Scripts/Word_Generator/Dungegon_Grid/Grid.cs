using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Vector3[,,] grid;
    public int sizeX = 10;
    public int sizeY = 1;
    public int sizeZ = 10;
    public bool showGrid;
    public float pointsInGridSize = 0.1f;
    public static float delta = 1f;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Vector3[sizeX, sizeY, sizeZ];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int z = 0; z < grid.GetLength(2); z++)
                {
                    // Lo multiplico por delta para que cada punto tenga una separacion
                    grid[x, y, z] = new Vector3(x, y, z) * delta;
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
                    Gizmos.DrawWireSphere(grid[x, y, z], pointsInGridSize);
                }
            }
        }
    }
}
