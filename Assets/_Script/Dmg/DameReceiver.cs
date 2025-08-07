using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiver : MonoBehaviour
{
   [SerializeField] protected float hp = 1;
   [SerializeField] protected float hpMax = 3;
    [SerializeField] protected bool isDead = false;
    void OnEnable()
    {
        ReBorn();
    }

    void Update()
    {
        
    }

    public virtual void ReBorn(){
        hp = hpMax;
        isDead = false;
    }

    public virtual void Add(float add){
        hp+=add;
        if(hp > hpMax) hp = hpMax;
    }

    public virtual void Reduce(float reduce){
        if(isDead) {
            //  Debug.Log($"{gameObject.name} bị bắn nhưng đã chết từ trước");
             CheckDead(); //thêm dòng này vì có con zom nó k biến mất khi máu = 0
             return;
        }
        hp -= reduce;
        if (hp <= 0) hp = 0;
        CheckDead();
    }
    public virtual bool IsDead(){
        return hp<=0;
    }
    protected virtual void CheckDead()
    {
        if(!IsDead())return;
        if(hp<=0) {
            isDead = true;
            OnDead();
        }
    }
    protected virtual void OnDead()
    {
        //override dead method
    }

    
}
