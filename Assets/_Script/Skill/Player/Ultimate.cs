using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : ObjSkill
{
    protected bool used;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    private bool isInvokingSkill = false;
    void FixedUpdate()
    {
        SkillReady();
        Used();
        DelaySkill();
        // SkillPower();
    }

    protected override bool Used()
    {
        used = InputManager.Instance.Ultimate == 1;
        return used;
    }
    protected override void DelaySkill()
    {
        if (!used) return;
        if (!isReady) return;
        if (isInvokingSkill) return;
        isInvokingSkill = true;
        isReady = false;
        Invoke(nameof(SkillPower), 0.3f);
    }
    protected override void SkillPower()
    {
       
        CreateSkillEffect();
        List<Transform> zombieList = new List<Transform>();
        foreach (Transform zombie in ZombieSpawner.Instance.holder)
        {
            zombieList.Add(zombie);
        }
        foreach (Transform zombie in zombieList)
        {
            EnemyCtrl ctrl = zombie.GetComponent<EnemyCtrl>();
            if (ctrl != null)
            {
                ctrl.Despawn.DespawnObj();
            }
        }
        isInvokingSkill = false;
       
        
    }

    protected override void CreateSkillEffect()
    {
        Debug.Log("Spawn effect: " + FXSpawner.ultimate);
        Transform fxImpactEffect = FXSpawner.Instance.SpawnByName(FXSpawner.ultimate, transform.position, transform.rotation);
        fxImpactEffect.gameObject.SetActive(true);
    }
}
