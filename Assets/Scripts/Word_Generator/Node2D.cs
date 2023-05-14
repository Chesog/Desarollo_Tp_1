using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;


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
    public Dictionary<string, RNode_Type[]>[] Possible_Neighbors =  
    {
        // Faltaria Forward y back para la 3 dimension

        // RNode_Type Empty
        new Dictionary<string, RNode_Type[]>
        {
            {"Up",new RNode_Type[]{RNode_Type.Normal,RNode_Type.Trap, RNode_Type.Boss} },
            {"Down",new RNode_Type[]{RNode_Type.Trap} },
            {"Right",new RNode_Type[]{RNode_Type.Normal,RNode_Type.Spawn} },
            {"Left",new RNode_Type[]{RNode_Type.Empty} }
        },

        // RNode_Type Spawn
        new Dictionary<string, RNode_Type[]>
        {
            {"Up",new RNode_Type[]{RNode_Type.Normal} },
            {"Down",new RNode_Type[]{ RNode_Type.Normal } },
            {"Right",new RNode_Type[]{ RNode_Type.Normal } },
            {"Left",new RNode_Type[]{ RNode_Type.Normal } }
        },

        // RNode_Type Trap
        new Dictionary<string, RNode_Type[]>
        {
            {"Up",new RNode_Type[]{RNode_Type.Empty , RNode_Type.Spawn, RNode_Type.Trap, RNode_Type.Normal, RNode_Type.Boss} },
            {"Down",new RNode_Type[]{ RNode_Type.Empty, RNode_Type.Spawn, RNode_Type.Trap, RNode_Type.Normal, RNode_Type.Boss } },
            {"Right",new RNode_Type[]{ RNode_Type.Empty, RNode_Type.Spawn, RNode_Type.Trap, RNode_Type.Normal, RNode_Type.Boss } },
            {"Left",new RNode_Type[]{ RNode_Type.Empty, RNode_Type.Spawn, RNode_Type.Trap, RNode_Type.Normal, RNode_Type.Boss } }
        },

        // RNode_Type Normal
        new Dictionary<string, RNode_Type[]>
        {
            {"Up",new RNode_Type[]{RNode_Type.Empty , RNode_Type.Spawn, RNode_Type.Normal, RNode_Type.Trap } },
            {"Down",new RNode_Type[]{RNode_Type.Empty , RNode_Type.Spawn, RNode_Type.Normal, RNode_Type.Trap } },
            {"Right",new RNode_Type[]{RNode_Type.Empty , RNode_Type.Spawn, RNode_Type.Normal, RNode_Type.Trap } },
            {"Left",new RNode_Type[]{RNode_Type.Empty , RNode_Type.Spawn, RNode_Type.Normal, RNode_Type.Trap } }
        },

        // RNode_Type Boss
        new Dictionary<string, RNode_Type[]>
        {
            {"Up",new RNode_Type[]{RNode_Type.Normal,RNode_Type.Trap} },
            {"Down",new RNode_Type[]{ RNode_Type.Normal, RNode_Type.Trap } },
            {"Right",new RNode_Type[]{RNode_Type.Normal, RNode_Type.Trap } },
            {"Left",new RNode_Type[]{RNode_Type.Normal, RNode_Type.Trap } }
        },
    };
    public Vector3Int gridpos;

    private void Start()
    {
        
    }
    public Node2D(Vector3 pos, Vector3Int gridpos)
    {
        this.pos = pos;
        this.gridpos = gridpos;

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
        return possible_Types.Count - obj.possible_Types.Count;
    }
}
