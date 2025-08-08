using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSkill : MonoBehaviour
{
    protected float delay = 2;
    protected float timer = 0;
    protected bool isReady = false;


    protected void SkillReady()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            isReady = true;
        }
    }
    protected abstract bool Used();
    protected abstract void SkillPower();
  

}
