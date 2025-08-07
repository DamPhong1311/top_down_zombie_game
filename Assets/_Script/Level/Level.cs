using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 99;
    public int LevelCurrent =>  levelCurrent;
    public int LevelMax =>  levelMax;

    public virtual void LevelUp(){
        levelCurrent++;
        LimitLevel();
    }
    public virtual void LevelSet(int newLevel){
        levelCurrent = newLevel;
        LimitLevel();
    }

    public virtual void LimitLevel()
    {
        if(levelCurrent > levelMax) levelCurrent = levelMax;
        if(levelCurrent < 1) levelCurrent = 1;
    }
}
