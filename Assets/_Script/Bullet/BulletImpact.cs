using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : MonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    void Awake()
    {
        if (bulletCtrl == null) Debug.LogError("bulletCtrl is null");
        if (sphereCollider == null) Debug.LogError("sphereCollider is null");
        if (_rigidbody == null) Debug.LogError("_rigidbody is null ");
    }
 
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.transform.root == ShooterCtrl.Instance.shooter) return;
        CheckItem checkItem = other.transform.parent.GetComponentInChildren<CheckItem>();
        if(checkItem != null) return; // là item thì bỏ qua
        Enemy enemy = other.transform.parent.GetComponentInChildren<Enemy>();
        if (enemy == null) return;
        bulletCtrl.DameSender.CheckTargetToSendDmg(other.transform);
    }

   
}
