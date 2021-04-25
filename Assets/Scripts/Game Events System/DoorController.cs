using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onDoorWayTriggerEnter += OnDoorwayOpen;
        GameEvents.Instance.onDoorWayTriggerExit += OnDoorwayClose;
    }

   private void OnDoorwayOpen(int id)
    {
        Debug.Log("Hello");
        if(id == this.id)
        {
            Debug.Log(id);
            LeanTween.moveLocalY(gameObject, 8f, 1f).setEaseOutQuad();
        }
    }
    private void OnDoorwayClose(int id)
    {
        //Debug.Log("ByeBye");
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 2.5f, 2f).setEaseOutQuad();
        }
    }

    private void OnDestroy()
    {
        GameEvents.Instance.onDoorWayTriggerEnter -= OnDoorwayOpen;
        GameEvents.Instance.onDoorWayTriggerExit -= OnDoorwayClose;
    }
}
