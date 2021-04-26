using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleRooms : MonoBehaviour
{
    private int rnd;
    RoomTemplates templates;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onSpawnObstacles += SpawnObsRooms;
    }

   public void SpawnObsRooms()
   {
        templates = FindObjectOfType<RoomTemplates>();
        foreach (GameObject g in templates.rooms)
        {
            rnd = Random.Range(0, templates.obstacles.Length);
            if (g.name != "EntryRoom" && g.name != "EntryRoom01" && g.name != "EntryRoom02" && g.name != "EntryRoom03" && g.transform.position != new Vector3(0, 0, 0))
            {
                GameObject go = g.gameObject.transform.Find("DoorTrigger").gameObject;
                Destroy(go);
                Instantiate(templates.obstacles[rnd], g.transform.position, Quaternion.identity);
                //GameEvents.Instance.DoorActivate(g.name, g.transform.position);
                templates.numRooms = 20;
            }
        }
   }

    private void OnDestroy()
    {
        GameEvents.Instance.onSpawnObstacles -= SpawnObsRooms;
    }
}
