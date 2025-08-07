using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeImpactFromZombie : MeleeImpact
{
    [SerializeField] protected Transform player;


    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Đã xác định là Player, gọi xử lý từ base");
        base.OnTriggerEnter(other);

    }
}
