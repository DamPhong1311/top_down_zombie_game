using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{

    [SerializeField] protected Vector3 targetPostion;
    [SerializeField] protected float speed = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveWithMouseMethod(GetMouseTargetPos()); // đi đến vị trí GetTargetPos()
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        Vector3 diff = this.targetPostion - transform.parent.position;
        diff.Normalize(); //Normalize() biến diff thành một vector đơn vị (độ dài = 1), giúp loại bỏ ảnh hưởng của khoảng cách giữa đối tượng cha và mục tiêu.
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 270);
    }

    protected Vector3 GetMouseTargetPos()
    {
        this.targetPostion = InputManager.Instance.MouseWorldPos; // targetPositon được lấy qua InputManager và lấy vị trí hiện tại của trỏ chuột
        this.targetPostion.z = 0;
        return this.targetPostion;
    }

    protected virtual void MoveWithMouseMethod(Vector3 targetPos)
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, speed);
        transform.parent.position = newPos;
    }
}
