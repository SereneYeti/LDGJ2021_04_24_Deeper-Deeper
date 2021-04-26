using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Create : MonoBehaviour
{
    public GameObject door;
    public float waitTime = 1f;
    private void Start()
    {
        LeanTween.moveLocalY(gameObject, 2f, 1f).setEaseOutQuad();
        Destroy(gameObject, waitTime);
    }

    private void Update()
    {
        //LeanTween.moveLocalY(gameObject, 1f, 2f).setEaseInOutQuad();
  
    }
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("is anyone out there!>!!?1");
        //Destroy(other.gameObject);
        //if (other.CompareTag("Rooms"))
        //{

        //    //Instantiate(door, this.transform.position, Quaternion.identity);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("is anyone out there!>!!?2");        
        if (collision.gameObject.CompareTag("Rooms")|| collision.gameObject.CompareTag("Lava"))
        {
            Destroy(collision.gameObject);
            //Instantiate(door, this.transform.position, Quaternion.identity);
        }
    }   

}
   

