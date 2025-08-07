using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawner : DespawnByDistance
{
   public override void DespawnObj()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
