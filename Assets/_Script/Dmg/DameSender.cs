using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : MonoBehaviour
{
    [SerializeField] protected float dmg = 1f;

    public virtual void CheckTargetToSendDmg(Transform obj){
        DameReceiver dameReceiver = obj.GetComponentInChildren<DameReceiver>();
        if(dameReceiver == null) return;
        SendDamage(dameReceiver);
        CreateImpactEffectFX();
    }
     protected virtual void CreateImpactEffectFX()
    {
        string nameFX = GetImpactFXName();
        Transform fxImpactEffect = FXSpawner.Instance.SpawnByName(nameFX, transform.position, transform.rotation);
        fxImpactEffect.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.impact_1;
    }

    public virtual void SendDamage(DameReceiver dameReceiver){
        dameReceiver.Reduce(dmg);
    }

   
}
