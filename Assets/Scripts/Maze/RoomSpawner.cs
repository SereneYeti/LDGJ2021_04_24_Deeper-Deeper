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
    private bool empty = false;
    
    void Start()
    {
        Destroy(gameObject, 4f);       
        templates = GameObject.FindObjectOfType<RoomTemplates>();
        
        templates.numRooms = gameManager.Instance.depth;
        Debug.Log(gameManager.Instance.depth);
        if (!spawned)
            Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        empty = Physics.CheckSphere(this.gameObject.transform.position, 0.5f);
        foreach (GameObject g in templates.rooms)
        {
            if (transform.position == g.transform.position)
            {
                spawned = true;
            }
        }
        if (spawned == false && templates.numRooms > 0 && empty == true)
        {
            switch (openingDir)
            {
                case 1:
                    {
                        
                        //1 -> need bottom door
                        if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms != 1)
                        {
                            rnd = Random.Range(0, templates.BottomRooms.Length);
                            Instantiate(templates.BottomRooms[rnd], transform.position, templates.BottomRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else if(transform.position != templates.entryRoom.position && spawned == false && templates.numRooms == 1)
                        {
                            rnd = Random.Range(0, templates.BottomRooms.Length);
                            Instantiate(templates.BottomRooms[0], transform.position, templates.BottomRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else
                        {
                            templates.numRooms--;
                        }
                        break;
                    }
                case 2:
                    {
                        //foreach (GameObject g in templates.rooms)
                        //{
                        //    if (transform.position == g.transform.position)
                        //    {
                        //        spawned = true;
                        //    }
                        //}
                        //2 -> need top door
                        if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms != 1)
                        {
                            rnd = Random.Range(0, templates.TopRooms.Length);
                            Instantiate(templates.TopRooms[rnd], transform.position, templates.TopRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms == 1)
                        {
                            rnd = Random.Range(0, templates.TopRooms.Length);
                            Instantiate(templates.TopRooms[0], transform.position, templates.TopRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else
                        {
                            templates.numRooms--;
                        }
                        break;
                    }
                case 3:
                    {
                        //foreach (GameObject g in templates.rooms)
                        //{
                        //    if (transform.position == g.transform.position)
                        //    {
                        //        spawned = true;
                        //    }
                        //}
                        //3 -> need left door
                        if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms != 1)
                        {
                            rnd = Random.Range(0, templates.LeftRooms.Length);
                            Instantiate(templates.LeftRooms[rnd], transform.position, templates.LeftRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms == 1)  //spawns a room at the one door 
                        {
                            rnd = Random.Range(0, templates.LeftRooms.Length);
                            Instantiate(templates.LeftRooms[0], transform.position, templates.LeftRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else
                        {
                            templates.numRooms--;
                        }
                        break;
                    }
                case 4:
                    {
                        //foreach (GameObject g in templates.rooms)
                        //{
                        //    if (transform.position == g.transform.position)
                        //    {
                        //        spawned = true;
                        //    }
                        //}
                        //4 -> need right door
                        if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms != 1)
                        {
                            rnd = Random.Range(0, templates.RightRooms.Length);
                            Instantiate(templates.RightRooms[rnd], transform.position, templates.RightRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else if (transform.position != templates.entryRoom.position && spawned == false && templates.numRooms == 1)
                        {
                            rnd = Random.Range(0, templates.RightRooms.Length);
                            Instantiate(templates.RightRooms[0], transform.position, templates.RightRooms[rnd].transform.rotation);
                            templates.numRooms--;
                        }
                        else
                        {
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
        //Debug.Log("!!!!");
        if(other.CompareTag("Spawn Point"))
        {
            foreach (GameObject g in templates.rooms)
            {
                if (transform.position == g.transform.position)
                {
                    spawned = true;
                }
            }
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);                
            }
            Destroy(gameObject);
            spawned = true;
        }

        if (other.CompareTag("Rooms"))
        {
            Debug.Log("Room");
            //if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            //{
            //    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            //}
            //Destroy(gameObject);
            //spawned = true;
        }
    }
}
