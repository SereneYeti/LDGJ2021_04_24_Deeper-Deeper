using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    #region Singleton Setup
    private static gameManager instance;

    public static gameManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    // Start is called before the first frame update

    public int depth = 10;

    private void Start()
    {
        //depth = 12;
    }

}
