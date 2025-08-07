using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePoolDespawn : DespawnByDistance
{
    public override void DespawnObj()
    {
        ZombieSpawner.Instance.Despawn(transform.parent);
    }
}
