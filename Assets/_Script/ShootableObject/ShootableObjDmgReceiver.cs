using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjDmgReceiver : DameReceiver
{
    [Header("ShootableObj")]
    [SerializeField] protected ShootableObjectCtrlAbtract ctrl;
    protected override void OnDead()
    {
        OnDeadFX();
        DropOnDead();
        ctrl.Despawn.DespawnObj(); 
    }

    protected virtual void DropOnDead(){
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        ItemDropSpawner.Instance.Drop(ctrl.ShootableObjectSO.dropList, pos, rot);
    }

    protected virtual void OnDeadFX(){
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.SpawnByName(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.dead_1;
    }

    public override void ReBorn()
    {
        hpMax = ctrl.ShootableObjectSO.hpMax;
        base.ReBorn();
        
    }
}
