using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    Canvas tutScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        tutScreen = GetComponent<Canvas>();
    }
    private void Update()
    {
        StartCoroutine(TutorialScreenTimer());
    }
    public IEnumerator TutorialScreenTimer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            yield return new WaitForSeconds(1f);
            tutScreen.enabled = false;
        }

    }
}
