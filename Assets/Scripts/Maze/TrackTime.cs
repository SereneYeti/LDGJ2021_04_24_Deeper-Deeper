using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TrackTime : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI tmTimeRemaining;
    int calc;

    private void Start()
    {
        calc = 5; 
        time = Time.timeSinceLevelLoad;
        StartCoroutine(reloadTimer(300f));
    }
    void Update()
    {
        //time += Time.deltaTime;
        //if(time == 15f)
        //{
        //    Debug.Log("!!!");
        //    SceneManager.LoadScene(1);
        //}
        //Debug.Log(time);
        //if(time%60==0&& time > 0)
        //{
        //    Debug.Log("!!!");
        //    calc--;
        //}

        
    }

    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = 0;
        //Debug.Log("!!!");
        while (counter < reloadTimeInSeconds)
        {
            counter += Time.deltaTime;
            tmTimeRemaining.text = "Time Remaining: " + (reloadTimeInSeconds - Mathf.RoundToInt(counter)) + " seconds";
            yield return null;
        }

        //Load new Scene
        SceneManager.LoadScene(0);
    }
}
