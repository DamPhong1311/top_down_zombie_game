using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackWithRange : AttackBase
{
    [SerializeField] private float bulletSpeed = 13f;

    protected override bool CheckAttackInput()
    {
        return InputManager.Instance.GetShootInput == 1;
    }

    protected override void PerformAttack()
    {
        Vector3 mousePosition = InputManager.Instance.MouseWorldPos;
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - attackPoint.position).normalized;

        Transform bulletTransform = BulletSpawner.Instance.SpawnByName(BulletSpawner.bulletOne, transform.position, Quaternion.identity).transform;

        SetDirection(direction, bulletTransform);

        Rigidbody bulletRb = bulletTransform.GetComponent<Rigidbody>();
        bulletRb.gameObject.SetActive(true);
        bulletRb.velocity = direction * bulletSpeed;
    }

    protected void SetDirection(Vector3 direction, Transform obj)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        obj.rotation = Quaternion.Euler(0, 0, angle);
    }
}
