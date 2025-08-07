using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : Spawner
{
    private static MeleeSpawner instance;
    public static MeleeSpawner Instance { get => instance; }

    public static string meleeSword1 = "Melee_Sword_1";

    protected override void  Awake()
    {
        base.Awake();
        if (MeleeSpawner.instance != null) Debug.LogError("Only one MeleeSpawner is allowed to exist.");
        MeleeSpawner.instance = this;
    }
}
