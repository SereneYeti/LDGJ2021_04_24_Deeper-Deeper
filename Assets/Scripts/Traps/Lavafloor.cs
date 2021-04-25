using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavafloor : MonoBehaviour
{
    [SerializeField] GameObject spawnPos1;
    [SerializeField] GameObject spawnPos2;

    private int rnd;

    private void OnCollisionEnter(Collision collision)
    {
        rnd = Random.Range(0, 2);
        if(rnd == 0)
        {
            collision.gameObject.gameObject.transform.SetPositionAndRotation(spawnPos1.transform.position, Quaternion.identity);
        }
        else if (rnd == 1)
        {
            collision.gameObject.gameObject.transform.SetPositionAndRotation(spawnPos2.transform.position, Quaternion.identity);
        }
    }
}
