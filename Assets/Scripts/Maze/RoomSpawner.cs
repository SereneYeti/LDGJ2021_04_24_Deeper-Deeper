using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;    
    //1 -> need bottom door
    //2 -> need top door
    //3 -> need left door
    //4 -> need right door 

    private RoomTemplates templates;
    private int rnd;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindObjectOfType<RoomTemplates>();
        if(!spawned)
            Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if(spawned == false && templates.numRooms > 0)
        {
            switch (openingDir)
            {
                case 1:
                    {
                        //1 -> need bottom door
                        if(transform.position != templates.entryRoom.position)
                        {
                            rnd = Random.Range(0, templates.BottomRooms.Length);
                            Instantiate(templates.BottomRooms[rnd], transform.position, templates.BottomRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                       
                        break;
                    }
                case 2:
                    {
                        //2 -> need top door
                        if (transform.position != templates.entryRoom.position)
                        {
                            rnd = Random.Range(0, templates.TopRooms.Length);
                            Instantiate(templates.TopRooms[rnd], transform.position, templates.TopRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                           
                        break;
                    }
                case 3:
                    {
                        //3 -> need left door
                        if (transform.position != templates.entryRoom.position)
                        {
                            rnd = Random.Range(0, templates.LeftRooms.Length);
                            Instantiate(templates.LeftRooms[rnd], transform.position, templates.LeftRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                            
                        break;
                    }
                case 4:
                    {
                        //4 -> need right door
                        if (transform.position != templates.entryRoom.position)
                        {
                            rnd = Random.Range(0, templates.RightRooms.Length);
                            Instantiate(templates.RightRooms[rnd], transform.position, templates.RightRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }                            
                        break;
                    }
            }
            spawned = true;
        }      
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spawn Point"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);                
            }
            Destroy(gameObject);
            spawned = true;
        }
    }
}
