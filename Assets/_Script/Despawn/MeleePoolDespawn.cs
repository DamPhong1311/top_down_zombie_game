using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePoolDespawn : DespawnByTime
{
    public override void DespawnObj(){
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}