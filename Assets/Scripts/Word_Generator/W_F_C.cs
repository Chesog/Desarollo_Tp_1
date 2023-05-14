using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class W_F_C : MonoBehaviour
{
    [SerializeField] private Grid grid;
    //1. var model.now Overlappingodeimovt.N:3, width:48 height:48, periodicinput:true, pertedic:false,
    //    symmetry:8 ground:0 ):
    //2. model.Rum(random.Next, limit:#):
    //3.
    //Input - the training Image
    //N - HOW large of blocks(NoN) to sample from the Input as input patterns. (higher N leads to rising CPU
    //    and memory cost)
    //Width - The output width
    //Height - The output height
    //persedicingut-wther to sample the input across edges
    //periedic - whether the output should be sampled across edges to create edge-wrapping output
    //symetry - a value between 1..8. indicating how nany reflection and rotation symetries should be sampled
    //from the input


    // Start is called before the first frame update
    void Start()
    {
        grid.StartGrid();
        firsNodeSelection();
        SearchLeastEntropy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void firsNodeSelection() 
    {
        List<RNode_Type> rNode_Types = new List<RNode_Type>();

        int x = UnityEngine.Random.Range(0,grid.grid.GetLength(0));
        int y = UnityEngine.Random.Range(0,grid.grid.GetLength(1));
        int z = UnityEngine.Random.Range(0,grid.grid.GetLength(2));

        RNode_Type selectedType = (RNode_Type)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(RNode_Type)).Length));
        rNode_Types.Add(selectedType);


        grid.grid[x, y, z].possible_Types = rNode_Types;
        grid.grid[x, y, z].state = Node_States.Collapsed;
    }

    private void SearchLeastEntropy() 
    {
        List<Node2D> sorted_Grid = sortGrid(grid.grid);


    }

    private List<Node2D> sortGrid(Node2D[,,] grid_to_Sort) 
    {
        List<Node2D> output = new List<Node2D>();

        for (int x = 0; x < grid_to_Sort.GetLength(0); x++)
        {
            for (int y = 0; y < grid_to_Sort.GetLength(1); y++)
            {
                for (int z = 0; z < grid_to_Sort.GetLength(2); z++)
                {
                    output.Add(grid_to_Sort[x,y,z]);
                }
            }
        }

        output.Sort();

        return output;
    }
}
