using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeImpact : MonoBehaviour
{
    [SerializeField] protected MeleeCtrl meleeCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    void Awake()
    {
        if (meleeCtrl == null) Debug.LogError("bulletCtrl is null");
        if (sphereCollider == null) Debug.LogError("sphereCollider is null");
        if (_rigidbody == null) Debug.LogError("_rigidbody is null ");
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        meleeCtrl.DameSender.CheckTargetToSendDmg(other.transform);
        Debug.Log("da tru mau");
    }
    
}
