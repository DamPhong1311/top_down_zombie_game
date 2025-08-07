using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] protected bool isAttacking = false;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected float attackRate = 0.5f;
    protected float nextAttackTime = 0f;

    protected virtual void Start()
    {
        attackPoint = GetComponentInParent<Transform>();
    }

    protected virtual void FixedUpdate()
    {
        isAttacking = CheckAttackInput();
        if (isAttacking && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;
            PerformAttack();
        }
    }

    protected abstract bool CheckAttackInput();
    protected abstract void PerformAttack();
}
