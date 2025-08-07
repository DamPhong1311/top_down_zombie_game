using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MapSetTarget();
    }

    protected virtual void MapSetTarget(){
        if(this.target != null) return;
        PlayerCtrl playerCtrl = PlayerCtrl.Instance;
        SetTarget(playerCtrl.transform);
    }
}
