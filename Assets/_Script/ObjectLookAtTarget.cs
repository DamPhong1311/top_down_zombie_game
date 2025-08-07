using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtTarget : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPostion;
    [SerializeField] protected Vector3 direction;

 

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPostion - transform.parent.position;
        diff.Normalize(); //Normalize() biến diff thành một vector đơn vị (độ dài = 1), giúp loại bỏ ảnh hưởng của khoảng cách giữa đối tượng cha và mục tiêu.
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

   
}
