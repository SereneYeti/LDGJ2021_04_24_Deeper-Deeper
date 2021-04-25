using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public Transform entryRoom;
    public GameObject[] TopRooms;
    public GameObject[] BottomRooms;
    public GameObject[] RightRooms;
    public GameObject[] LeftRooms;

    public GameObject closedRoom;
    public List<GameObject> rooms;

    public int numRooms = 12;

    //Values for the last room 
    public float waitTime;
    private bool spawnedStairs;
    public GameObject stairs;

    private void Update()
    {
        CreateStairs();
    }
    public void CreateStairs()
    {
        if (waitTime <= 0 && spawnedStairs == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count-1)
                {
                    DestroyCenter(i);
                    Instantiate(stairs, rooms[i].transform.position, Quaternion.identity);
                    spawnedStairs = true;

                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void DestroyCenter(int i)
    {
        GameObject go = rooms[i].transform.Find("Center").gameObject;
        Destroy(go);
    }
}


