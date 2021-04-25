using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Singleton Setup
    private static GameEvents instance;

    public static GameEvents Instance
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

    public event Action<int> onDoorWayTriggerEnter;
    public void DoorwayTriggerEnter(int id)
    {
        if (onDoorWayTriggerEnter != null)
        {
            onDoorWayTriggerEnter(id);
        }
    }

    public event Action<int> onDoorWayTriggerExit;
    public void DoorWayTriggerExit(int id)
    {
        if (onDoorWayTriggerExit != null)
        {
            onDoorWayTriggerExit(id);
        }
    }

    public event Action onSpawnObstacles;
    public void SpawnObstaclesTrigger()
    {
        if (onDoorWayTriggerExit != null)
        {
            onSpawnObstacles();
        }
    }
}
