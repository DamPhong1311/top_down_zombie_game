using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : ObjSkill
{
    protected bool used;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    void FixedUpdate()
    {
        Used();
        SkillPower();
    }

    protected override bool Used()
    {
        used = InputManager.Instance.Ultimate == 1;
        Debug.Log("test skill is using:" + InputManager.Instance.Ultimate);
        return used;
    }

    protected override void SkillPower()
    {
        if (!used) return;
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

        Debug.Log("Đã tiêu diệt hết zombie, số còn lại: " + ZombieSpawner.Instance.holder.childCount);
    }
}
