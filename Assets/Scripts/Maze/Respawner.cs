using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetPositionAndRotation(new Vector3(0, 1, 0), Quaternion.identity);
    }
}
