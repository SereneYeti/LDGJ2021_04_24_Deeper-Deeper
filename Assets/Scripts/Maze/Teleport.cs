using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(2);            
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            SceneManager.UnloadSceneAsync(2);
            SceneManager.LoadScene(3);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            SceneManager.UnloadSceneAsync(3);
            SceneManager.LoadScene(0);
        }
    }
}
