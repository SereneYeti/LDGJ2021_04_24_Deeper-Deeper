using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
     Rigidbody wall;

    public Renderer disRenderer;
    float targetDissolve = 100f;
    public float currentDislove = 1f;

     Vector3 endPos;
    Vector3 startPos;
    private float distance = 30f;
    public float lerpTime = 5f;
    public float currentlerpTime = 0;
    private bool keyhit = false;
    string startPosn;
    string endPosn;


    private void Start()
    {
        
      
    }

    private void Update()
    {
        // MovingObjects();
    
    }
    private void FixedUpdate()
    {
       // shiftColor();
    }

    public void MovingObjects()
    {
        currentlerpTime += Time.deltaTime;
        if (currentlerpTime >= lerpTime)
        {
            currentlerpTime = lerpTime;
        }

        float perc = currentlerpTime / lerpTime;
        
        wall.transform.position = Vector3.Lerp(startPos, endPos, perc);
    }


    public void shiftColor()
    {
        currentlerpTime += Time.deltaTime;

        currentDislove = Mathf.Lerp(currentDislove, targetDissolve, 2f * Time.deltaTime);
        disRenderer.material.SetFloat("_CutoffHeight", currentDislove);

        if (currentlerpTime >= lerpTime)
        {
            targetDissolve += 0.0001f;
            currentlerpTime = lerpTime;
            Debug.Log(Time.deltaTime.ToString());        
        }

        else if (currentDislove >= 1f)
        {
             targetDissolve= -1f;

        }
        else if (currentDislove <= -1f)
        {

            targetDissolve = 1f;
            
        }



    }
    
}
