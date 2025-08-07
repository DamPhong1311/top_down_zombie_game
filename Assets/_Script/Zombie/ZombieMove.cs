using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : ObjectLookAtTarget
{
    [SerializeField] protected Transform targetObj;
    [SerializeField] protected float moveSpeed = 2f;
    private float stopSpace = 1.2f;
    void Awake()
    {
        if (targetObj == null) Debug.LogError("targetObj in ZombieMove is null");
    }

    void FixedUpdate()
    {
        Move();
        LookAtTarget();
    }

    protected override void LookAtTarget()
    {
        if (targetObj == null) return;
        targetPostion = targetObj.position;
        float deltaX = targetPostion.x - transform.parent.position.x;

        if (deltaX >= 0)
        {
            // Player ở bên phải → zombie nhìn sang phải
            transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            // Player ở bên trái → zombie nhìn sang trái
            transform.parent.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    protected void Move()
    {
        if (targetObj == null) return;

        float distance = Vector3.Distance(transform.parent.position, targetObj.position);
        if (distance < stopSpace) return;

        // Di chuyển zombie về phía targetObj
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetObj.position, moveSpeed * Time.deltaTime);

    }
}
