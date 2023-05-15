using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wfc_Dungeon_Generator : MonoBehaviour
{
    [SerializeField] private Grid gr;
    [SerializeField] private W_F_C wave;
    [SerializeField] private int boss_RoomsCant;
    [SerializeField] private int spawn_RoomsCant;
    [SerializeField] private List<GameObject> spawn_rooms_Prefab; // Empty = 0, Spawn = 1, Trap = 2, Norma = 3, Boss = 4
    [SerializeField] private List<GameObject> trap_rooms_Prefab; // Empty = 0, Spawn = 1, Trap = 2, Norma = 3, Boss = 4
    [SerializeField] private List<GameObject> normal_rooms_Prefab; // Empty = 0, Spawn = 1, Trap = 2, Norma = 3, Boss = 4
    [SerializeField] private List<GameObject> boss_rooms_Prefab; // Empty = 0, Spawn = 1, Trap = 2, Norma = 3, Boss = 4
    // Start is called before the first frame update
    void Start()
    {
        wave.StartWFC();
        CheckRoomCant();
        InstantiatePrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckRoomCant()
    {
        List<Node2D> boss_Rooms = new List<Node2D>();
        List<Node2D> spawn_Rooms = new List<Node2D>();

        for (int x = 0; x < gr.grid.GetLength(0); x++)
        {
            for (int y = 0; y < gr.grid.GetLength(1); y++)
            {
                for (int z = 0; z < gr.grid.GetLength(2); z++)
                {
                    // Check the Boss Rooms
                    if (gr.grid[x, y, z].type == RNode_Type.Boss)
                    {
                        boss_Rooms.Add(gr.grid[x, y, z]);
                    }

                    // Check the spawn Rooms
                    if (gr.grid[x, y, z].type == RNode_Type.Spawn)
                    {
                        spawn_Rooms.Add(gr.grid[x, y, z]);
                    }
                }
            }
        }

        if (boss_Rooms.Count == boss_RoomsCant && spawn_Rooms.Count == spawn_RoomsCant)
        {
            return;
        }
        else
        {
            if (boss_Rooms.Count > boss_RoomsCant || spawn_Rooms.Count > spawn_RoomsCant)
            {
                while (boss_Rooms.Count > boss_RoomsCant)
                {
                    List<RNode_Type> randList; 

                    int rand = UnityEngine.Random.Range(0, boss_Rooms.Count);
                    randList = wave.GetNodePossibilities(boss_Rooms[rand]);
                    randList.Remove(RNode_Type.Boss);
                    randList.Remove(RNode_Type.Spawn);

                    int rand2 = UnityEngine.Random.Range(0, randList.Count);
                    gr.grid[boss_Rooms[rand].gridpos.x, boss_Rooms[rand].gridpos.y, boss_Rooms[rand].gridpos.z].type = randList[rand2];

                    boss_Rooms.RemoveAt(rand);
                }
                boss_Rooms.Clear();

                while (spawn_Rooms.Count > spawn_RoomsCant)
                {
                    List<RNode_Type> randList;

                    int rand = UnityEngine.Random.Range(0, spawn_Rooms.Count);
                    randList = wave.GetNodePossibilities(spawn_Rooms[rand]);
                    randList.Remove(RNode_Type.Boss);
                    randList.Remove(RNode_Type.Spawn);

                    int rand2 = UnityEngine.Random.Range(0, randList.Count);
                    gr.grid[spawn_Rooms[rand].gridpos.x, spawn_Rooms[rand].gridpos.y, spawn_Rooms[rand].gridpos.z].type = randList[rand2];

                    spawn_Rooms.RemoveAt(rand);
                }
                spawn_Rooms.Clear();
            }
            else
            {
                wave.StartWFC();
                CheckRoomCant();
            }
        }
    }

    private void InstantiatePrefabs()
    {
        for (int x = 0; x < gr.grid.GetLength(0); x++)
        {
            for (int y = 0; y < gr.grid.GetLength(1); y++)
            {
                for (int z = 0; z < gr.grid.GetLength(2); z++)
                {
                    int index = 0;
                    switch (gr.grid[x,y,z].type)
                    {
                        case RNode_Type.Empty:
                            break;
                        case RNode_Type.Spawn:
                            index = UnityEngine.Random.Range(0, spawn_rooms_Prefab.Count);
                            Instantiate(spawn_rooms_Prefab[index], gr.grid[x, y, z].pos,Quaternion.identity);
                            break;
                        case RNode_Type.Trap:
                            index = UnityEngine.Random.Range(0, trap_rooms_Prefab.Count);
                            Instantiate(trap_rooms_Prefab[index], gr.grid[x, y, z].pos, Quaternion.identity);
                            break;
                        case RNode_Type.Normal:
                            index = UnityEngine.Random.Range(0, normal_rooms_Prefab.Count);
                            Instantiate(normal_rooms_Prefab[index], gr.grid[x, y, z].pos, Quaternion.identity);
                            break;
                        case RNode_Type.Boss:
                            index = UnityEngine.Random.Range(0, boss_rooms_Prefab.Count);
                            Debug.LogWarning("Boss Room Count " + boss_rooms_Prefab.Count);
                            Debug.LogWarning("Boss Room Index " + index);
                            Instantiate(boss_rooms_Prefab[index], gr.grid[x, y, z].pos, Quaternion.identity);
                            break;
                        default:
                            Debug.LogError("No Rooms To spawn");
                            break;
                    }
                }
            }
        }
    }
}
