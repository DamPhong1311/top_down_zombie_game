using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    // [SerializeField] protected Rigidbody2D bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float speed = 13f;
    [SerializeField] private float fireRate = 0.2f; // Giãn cách thời gian giữa các viên đạn (giây)
    private float nextFireTime = 0f; // Lưu thời điểm có thể bắn tiếp theo


    void Start()
    {
        firePoint = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsShooting();
        Shooting();
        
    }

    protected virtual bool IsShooting()
    {
        isShooting = InputManager.Instance.GetShootInput == 1;
        return isShooting;
    }

    protected void Shooting()
    {
        if (!isShooting) return;
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        Vector3 mousePosition = InputManager.Instance.MouseWorldPos;
        mousePosition.z = 0;
        

        Vector3 direction = (mousePosition - firePoint.position).normalized;

        Transform bulletTransform = BulletSpawner.Instance.SpawnByName(BulletSpawner.bulletOne, transform.position, Quaternion.identity).transform;
        SetDirection(direction, bulletTransform);

        Rigidbody bulletInstance = bulletTransform.GetComponent<Rigidbody>();
        bulletInstance.gameObject.SetActive(true);
        bulletInstance.velocity = direction * speed;
    }

    protected virtual void SetDirection(Vector3 direction, Transform obj){
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        obj.rotation = Quaternion.Euler(0, 0, angle);
    }
    
}
