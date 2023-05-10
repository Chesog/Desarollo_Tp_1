using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public enum Node_States { UnCollapsed, Collapsed }
//public enum Node_Type {Empty,Floor,Wall,Door}
public enum RNode_Type { Empty, Spawn, Trap, Normal, Boss }

[System.Serializable]
public class Node2D : MonoBehaviour
{
    public GameObject node_obj;
    public RNode_Type type;
    public Vector3 pos;
    public List<Node2D> up_objs;
    public List<Node2D> down_objs;
    public List<Node2D> left_objs;
    public List<Node2D> right_objs;


    public static Node2D operator *(Node2D v3, float scalar)
    {
        return new Node2D(v3.pos.x * scalar, v3.pos.y * scalar, v3.pos.z * scalar);
    }

    public Node2D(float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
    }

    public Node2D(RNode_Type node_Type, Vector3 pos, GameObject obj)
    {
        this.pos = pos;
        node_obj = obj;
        type = node_Type;

    }
}
