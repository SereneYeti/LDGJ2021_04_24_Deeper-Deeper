using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Create : MonoBehaviour
{
    public GameObject door;
    private void Start()
    {
        LeanTween.moveLocalY(gameObject, 100f, 1f).setEaseOutQuad();
        //Destroy(gameObject, 4f);
    }

    private void Update()
    {
        LeanTween.moveLocalY(gameObject, 1f, 2f).setEaseInOutQuad();
  
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
   

