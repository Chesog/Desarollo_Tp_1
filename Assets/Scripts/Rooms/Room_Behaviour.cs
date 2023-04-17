using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Behaviour : MonoBehaviour
{
    [Header("Room SetUp")]
    [SerializeField] private GameObject[] walls;      // 0 = Up - 1 = Down - 2 = Right - 3 = Left
    [SerializeField] private GameObject[] doors;      // 0 = Up - 1 = Down - 2 = Right - 3 = Left
    [SerializeField] private Transform playerPos;
    [SerializeField] private float updateTimer = 2.0f;
    [Header("Room Points")]
    [SerializeField] private const int maxRoomPoints = 8;
    [SerializeField] private const int maxRoomPlanes = 4;
    [SerializeField] private Transform[] roomPoints = new Transform[maxRoomPoints];
    [SerializeField] private Plane[] roomPlanes = new Plane[maxRoomPlanes];
    [Header("Rooms Checks")]
    [SerializeField] private bool isRoomVisible;
    [SerializeField] private bool isRoomCheked;
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float rayDistance;
    [SerializeField] List<Room_Behaviour> adjRooms;



    private void Start()
    {

        for (int i = 0; i < maxRoomPlanes; i++)
        {
            roomPlanes[i] = new Plane();
        }
        roomPlanes[0].Set3Points(roomPoints[0].position, roomPoints[1].position, roomPoints[3].position);
        roomPlanes[1].Set3Points(roomPoints[4].position, roomPoints[0].position, roomPoints[2].position);
        roomPlanes[2].Set3Points(roomPoints[5].position, roomPoints[4].position, roomPoints[6].position);
        roomPlanes[3].Set3Points(roomPoints[1].position, roomPoints[5].position, roomPoints[7].position);
    }

    private void Update()
    {
        if (isRoomVisible)
        {
            Show();
        }
        else
        {
            Hide();
        }

        if (isRoomCheked)
        {
            updateTimer -= Time.deltaTime;
            if (updateTimer < 0.0f)
            {
                updateTimer = 2.0f;
                isRoomCheked = false;
                isRoomVisible = false;
            }
        }
    }
    public bool isPointInside(Vector3 pos)
    {
        for (int i = 0; i < roomPlanes.Length; i++)
        {
            if (!roomPlanes[i].GetSide(pos))
            {
                return false;
            }
        }

        return true;
    }

    public void SetRoomVisible(bool value) 
    {
        isRoomVisible = value;
    }

    public void SetRoomCheked(bool value)
    {
        isRoomCheked = value;
    }

    public bool GetRoomVisible() 
    {
        return isRoomVisible;
    }

    public bool GetRoomCheked() 
    {
        return isRoomCheked;
    }

    public void UpdateRoom(bool[] status) 
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }

    public void SetAdjRooms() 
    {
        RaycastHit hit;

        if (doors[0].activeInHierarchy)
        {
            if (Physics.Raycast(rayOrigin.position, Vector3.forward, out hit, rayDistance))
            {
                adjRooms.Add(hit.collider.GetComponentInParent<Room_Behaviour>());
            }
        }

        if (doors[1].activeInHierarchy)
        {
            if (Physics.Raycast(rayOrigin.position, -Vector3.forward, out hit, rayDistance))
            {
                adjRooms.Add(hit.collider.GetComponentInParent<Room_Behaviour>());
            }
        }

        if (doors[2].activeInHierarchy)
        {
            if (Physics.Raycast(rayOrigin.position, Vector3.right, out hit, rayDistance))
            {
                adjRooms.Add(hit.collider.GetComponentInParent<Room_Behaviour>());
            }
        }

        if (doors[3].activeInHierarchy)
        {
            if (Physics.Raycast(rayOrigin.position, Vector3.left, out hit, rayDistance))
            {
                adjRooms.Add(hit.collider.GetComponentInParent<Room_Behaviour>());
            }
        }
    }

    public void ShowAdjRooms() 
    {
        foreach (var item in adjRooms)
        {
            item.SetRoomCheked(true);
            item.SetRoomVisible(true);
        }
    }

    public void Hide()
    {

        MeshRenderer[] mesh = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].enabled = false;
        }
    }

    public void Show()
    {
        MeshRenderer[] mesh = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(rayOrigin.position,Vector3.forward * rayDistance);
        Gizmos.DrawRay(rayOrigin.position, - Vector3.forward * rayDistance);
        Gizmos.DrawRay(rayOrigin.position,Vector3.left * rayDistance);
        Gizmos.DrawRay(rayOrigin.position,Vector3.right * rayDistance);
    }
}
