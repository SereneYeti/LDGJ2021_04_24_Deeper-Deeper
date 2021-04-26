using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private void Start()
    {
        //CreateStairhole();
    }
    public void CreateStairhole()
    {
        //Debug.Log("test");
        //Debug.Log(spawnedStairs);
        //Debug.Log(waitTime);
        RoomTemplates roomTemplates = FindObjectOfType<RoomTemplates>();
        if (roomTemplates.spawnedStairs == true)
        {
            Debug.Log("I Did it!");
            for (int i = 0; i < roomTemplates.obstacles.Length; i++)
            {
                if (i == roomTemplates.obstacles.Length - 1)
                {
                    roomTemplates.DestroyObsCenter(i);
                    //Debug.Log("I Did it!");

                }
            }
        }
        else
        {
            //waitTime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            //SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(1);            
        }
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        //{
        //    //SceneManager.UnloadSceneAsync(2);
        //    SceneManager.LoadScene(3);
        //}
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        //{
        //    //SceneManager.UnloadSceneAsync(3);
        //    SceneManager.LoadScene(0);
        //}
    }
}
