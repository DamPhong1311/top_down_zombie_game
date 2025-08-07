using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] public float delay = 0.1f;
    [SerializeField] public float timer = 0;

    void OnEnable()
    {
        ResetTimer();
    }

    protected virtual void ResetTimer(){
        this.timer = 0;
    }

    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        return timer > delay;
    }

}
