using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmgSender : DameSender
{

    [SerializeField] protected BulletCtrl bulletCtrl;

    public override void CheckTargetToSendDmg(Transform obj){
        base.CheckTargetToSendDmg(obj);
        DestroyBullet();
    }
    protected void DestroyBullet(){
        // Destroy(transform.parent.gameObject);
        bulletCtrl.BulletPoolDespawn.DespawnObj();
    }
}
