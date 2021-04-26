using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public GameObject doorTop;
    public GameObject doorBotton;
    public GameObject doorLeft;
    public GameObject doorRight;

    private void Start()
    {
        GameEvents.Instance.onDoorsActivate += ActivateDoors;
        //doorTop.SetActive(false);
        //doorBotton.SetActive(false);
        //doorRight.SetActive(false); 
        //doorLeft.SetActive(false);
    }

    public void ActivateDoors(string name, Vector3 pos)
    {
        if(pos == this.transform.position)
        {
            switch (name)
            {
                case "T":
                    {
                        //Z = 15 X = 0
                        doorTop.SetActive(true);
                        break;
                    }
                case "LT":
                    {
                        doorLeft.SetActive(true);
                        doorTop.SetActive(true);
                        break;
                    }
                case "TB":
                    {
                        doorTop.SetActive(true);
                        doorBotton.SetActive(true);
                        break;
                    }
                case "TR":
                    {
                        doorTop.SetActive(true);
                        doorRight.SetActive(true);
                        break;
                    }
                case "B":
                    {   //Z = -15 X = 0
                        doorBotton.SetActive(true);
                        break;
                    }
                case "RB":
                    {
                        doorBotton.SetActive(true);
                        doorRight.SetActive(true);
                        break;
                    }
                case "LB":
                    {
                        doorLeft.SetActive(true);
                        doorBotton.SetActive(true);
                        break;
                    }
                case "R":
                    {   //Z = 0 X = 15
                        doorRight.SetActive(true);
                        break;
                    }
                case "LR":
                    {
                        doorLeft.SetActive(true);
                        doorRight.SetActive(true);
                        break;
                    }
                case "L":
                    {   //Z = 0 X = -15
                        doorLeft.SetActive(true);
                        break;
                    }
            }
        }
        
    }

    private void OnDestroy()
    {
        GameEvents.Instance.onDoorsActivate -= ActivateDoors;
    }
}
