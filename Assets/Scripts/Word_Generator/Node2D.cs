using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public enum Node_States { UnCollapsed, Collapsed }
public enum RNode_Type { Empty, Spawn, Trap, Normal, Boss }

[Serializable]
public class Node2D : MonoBehaviour, IComparable<Node2D>
{
    public GameObject node_obj;
    public Node_States state;
    public Vector3 pos;
    public List<RNode_Type> possible_Types = new List<RNode_Type>();
    public RNode_Type type;


    public Node2D(float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;

        foreach (RNode_Type item in Enum.GetValues(typeof(RNode_Type)))
        {
            possible_Types.Add(item);
        }
    }

    public int CompareTo(Node2D obj)
    {
        //Before -> -1
        //After-> 1
        //Same-> 0
        return obj.possible_Types.Count - possible_Types.Count;
    }
}
