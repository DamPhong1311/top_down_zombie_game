using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Spawner
{
 
   
    private static ZombieSpawner instance;
    public static ZombieSpawner Instance { get => instance; }

    public static string zombieOne = "Zombie_1";
    protected override void Awake()
    {
        ZombieSpawner.instance = this;
        base.Awake();
        
    }
    

   
   
}
