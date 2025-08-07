using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{

    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float disLimit = 40f;

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position, GameCtrl.Instance.mainCamera.transform.position);
        if (distance > disLimit) return true;
        return false;
    }
}
