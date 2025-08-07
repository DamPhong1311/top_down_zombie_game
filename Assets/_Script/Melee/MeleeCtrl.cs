using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCtrl : MonoBehaviour
{
    [SerializeField] private DameSender dameSender; public DameSender DameSender { get => dameSender; }
    
    [SerializeField] private MeleePoolDespawn meleePoolDespawn; public MeleePoolDespawn MeleePoolDespawn { get => meleePoolDespawn; }



    void Awake()
    {
        if(dameSender == null)Debug.LogError("dameSender is null");
        if(meleePoolDespawn == null)Debug.LogError("bulletPoolDespawn is null");
    }

}
