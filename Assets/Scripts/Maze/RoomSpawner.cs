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
    void Start()
    {
        templates = GameObject.FindObjectOfType<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(openingDir)
        {
            case 1:
                {
                    //1 -> need bottom door
                    break;
                }
            case 2:
                {
                    //2 -> need top door
                    break;
                }
            case 3:
                {
                    //3 -> need left door
                    break;
                }
            case 4:
                {
                    //4 -> need right door
                    break;
                }
        }
    }
}
