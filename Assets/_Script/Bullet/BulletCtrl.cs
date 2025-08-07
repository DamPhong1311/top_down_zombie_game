using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private static BulletCtrl instance;
    public static BulletCtrl Instance { get => instance;}
    

    [SerializeField] private DameSender dameSender; public DameSender DameSender { get => dameSender; }
    
    [SerializeField] private BulletPoolDespawn bulletPoolDespawn; public BulletPoolDespawn BulletPoolDespawn { get => bulletPoolDespawn; }



    void Awake()
    {
        BulletCtrl.instance = this;
        if(dameSender == null)Debug.LogError("dameSender is null");
        if(dameSender == null)Debug.LogError("bulletPoolDespawn is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
