using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCtrl : MonoBehaviour
{
    [SerializeField] private  Spawner spawner; public  Spawner Spawner => spawner; 
    [SerializeField] private  Despawn despawn; public  Despawn Despawn => despawn;

    [SerializeField] private InventoryItem inventoryItem; public InventoryItem InventoryItem  => inventoryItem; 


    void Awake()
    {
        if(Spawner == null) Debug.LogError("spawner is null");
        if(despawn == null) Debug.LogError("despawn is null");
    }

    protected virtual void OnEnable()
    {
        ResetItem();
    }

    protected virtual void ResetItem(){
        inventoryItem.itemCount = 1;
        inventoryItem.level = 0;
    }

    public virtual void SetInventoryItem(InventoryItem inventoryItem){
        this.inventoryItem = inventoryItem.Clone();
    }
}
