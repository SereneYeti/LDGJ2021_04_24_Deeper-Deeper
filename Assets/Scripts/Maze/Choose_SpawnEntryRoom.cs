using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_SpawnEntryRoom : MonoBehaviour
{
    public GameObject[] entryLevels;
    private int rnd;
    public RoomTemplates templates;

    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(0, entryLevels.Length);
        templates = FindObjectOfType<RoomTemplates>();
        GameObject go = Instantiate(entryLevels[rnd], this.transform.position, Quaternion.identity);
        templates.entryRoom = go.transform;
    }
    
}
