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
    public GameObject[] obstacles;

    public GameObject closedRoom;
    public List<GameObject> rooms;

    public int numRooms = 12;

    //Values for the last room 
    public float waitTime;
    private bool spawnedStairs = false;
    public GameObject stairs;

    private void Start()
    {
        //Debug.Log("test");
        Invoke("CreateStairs", 2f);
    }

    private void Update()
    {
        
    }
    public void CreateStairs()
    {
        //Debug.Log("test");
        //Debug.Log(spawnedStairs);
        //Debug.Log(waitTime);
        if (spawnedStairs == false)
        {
            Debug.Log("I Did it!");
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count-1)
                {
                    DestroyCenter(i);
                    Instantiate(stairs, rooms[i].transform.position, Quaternion.identity);
                    spawnedStairs = true;
                    GameEvents.Instance.SpawnObstaclesTrigger();
                    //Debug.Log("I Did it!");

                }
            }
        }
        else
        {
            //waitTime -= Time.deltaTime;
        }
    }

    public void DestroyCenter(int i)
    {
        GameObject go = rooms[i].transform.Find("Center").gameObject;
        Destroy(go);
    }
}


