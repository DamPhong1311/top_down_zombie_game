using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSkill : MonoBehaviour
{
    protected float delay = 5;
    protected float timer = 0;
    protected bool isReady = false;


    protected void SkillReady()
    {
        if (isReady) return;
        timer += Time.deltaTime;
        if (timer > delay)
        {
            isReady = true;
            timer = 0;
            Debug.Log("Skill is ready");
        }
    }
    protected abstract bool Used();
    protected abstract void DelaySkill();
    protected abstract void SkillPower();
    protected abstract void CreateSkillEffect();
    
  

}
