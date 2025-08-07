using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 5f;
    
    private void FixedUpdate() {
        Following();
    }

    protected virtual void Following(){
        if(target == null)return;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed); 
    }
}
