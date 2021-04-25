using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCentreBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == true)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
