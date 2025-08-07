using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDmgSender : DameSender
{
    [SerializeField] protected MeleeCtrl meleeCtrl;

    public override void CheckTargetToSendDmg(Transform obj){
        base.CheckTargetToSendDmg(obj);
        // DestroyMelee();
    }
    protected void DestroyMelee(){
        // Destroy(transform.parent.gameObject);
        meleeCtrl.MeleePoolDespawn.DespawnObj();
    }
}
