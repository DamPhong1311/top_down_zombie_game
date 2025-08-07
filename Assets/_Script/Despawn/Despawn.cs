using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MonoBehaviour
{
    void FixedUpdate()
    {
        Despawning();
    }

    protected virtual void Despawning(){
        if(!CanDespawn())return;
        DespawnObj();
    }

    public virtual void DespawnObj(){
        Destroy(transform.parent.gameObject); 
    }

    protected abstract bool CanDespawn();
}
