using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Rigidbody wall;

    public Shader shaderShift;
    public Vector3 endPos;
    public Vector3 startPos;
    private float distance = 30f;
    public float lerpTime = 5f;
    private float currentlerpTime = 0;
    private bool keyhit = false;
    public string startPosn;
    public string endPosn;


    private void Start()
    {
        startPos = GameObject.Find("movPos00").transform.position;
        endPos = GameObject.Find("movPos01").transform.position + Vector3.right * distance;
    }

    private void Update()
    {
       // MovingObjects();
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
}
