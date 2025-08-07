using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string dead_1 = "Dead_1";
    public static string impact_1 = "Impact_1";

    protected override void  Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Only one FXSpawner is allowed to exist.");
        FXSpawner.instance = this;
    }
    
   
}
