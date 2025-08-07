using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolDespawn : DespawnByDistance
{
    public override void DespawnObj(){
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
