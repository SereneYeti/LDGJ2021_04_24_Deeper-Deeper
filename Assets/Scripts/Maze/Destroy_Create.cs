using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Create : MonoBehaviour
{
    public GameObject door;
    private void Start()
    {
        LeanTween.moveLocalY(gameObject, 8f, 1f).setEaseOutQuad();
        //Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is anyone out there!>!!?1");
        //Destroy(other.gameObject);
        //if (other.CompareTag("Rooms"))
        //{

        //    //Instantiate(door, this.transform.position, Quaternion.identity);
        //}
    }
}
   

