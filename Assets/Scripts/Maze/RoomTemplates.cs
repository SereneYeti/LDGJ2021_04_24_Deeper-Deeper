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
}
