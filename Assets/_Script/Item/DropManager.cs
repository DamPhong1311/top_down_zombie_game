using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private static DropManager instance;

    public static DropManager Instance => instance;

    void Awake()
    {
        if (DropManager.instance != null) Debug.LogError("Only one DropManager is allowed to exist.");
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList){
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
