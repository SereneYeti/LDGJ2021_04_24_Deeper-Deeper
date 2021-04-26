using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameEvents.Instance.DoorwayTriggerEnter(id);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitCloseDoor());
        }
    }

    public IEnumerator WaitCloseDoor()
    {
        yield return new WaitForSeconds(1f);
        GameEvents.Instance.DoorWayTriggerExit(id);

    }
}
