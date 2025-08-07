using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;

    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only one ItemDropSpawner is allowed to exist.");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 position, Quaternion rotation){
        foreach(DropRate drop in dropList) {
            ItemCode itemCode = drop.itemSO.itemCode;
            Transform itemDrop = SpawnByName(itemCode.ToString(), position, rotation);
            if (itemDrop == null) return;
            itemDrop.gameObject.SetActive(true);
        }
    }

    public virtual Transform Drop(InventoryItem inventoryItem, Vector3 pos, Quaternion rot){
        ItemCode itemCode = inventoryItem.itemProfile.itemCode;
        Transform itemDrop = SpawnByName(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemDropCtrl itemDropCtrl = itemDrop.GetComponent<ItemDropCtrl>();
        itemDropCtrl.SetInventoryItem(inventoryItem);
        return itemDrop;
    }
    
}
