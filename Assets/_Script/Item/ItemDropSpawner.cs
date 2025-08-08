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

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 position, Quaternion rotation)
    {

        List<ItemDropRate> itemsDropRate = new List<ItemDropRate>();
        if (dropList.Count < 1) return itemsDropRate;

        itemsDropRate = DropItems(dropList);
        foreach (ItemDropRate drop in itemsDropRate)
        {
            ItemCode itemCode = drop.itemSO.itemCode;
            Transform itemDrop = SpawnByName(itemCode.ToString(), position, rotation);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }
        return itemsDropRate;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> dropList)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        foreach (ItemDropRate item in dropList)
        {
            float rate = Random.Range(0, 1f); 
            // Debug.Log($"Random: {rate}, DropRate: {item.dropRate}");
            if (rate <= item.dropRate)
            {
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }

    public virtual Transform DropFromInventory(InventoryItem inventoryItem, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = inventoryItem.itemProfile.itemCode;
        Transform itemDrop = SpawnByName(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemDropCtrl itemDropCtrl = itemDrop.GetComponent<ItemDropCtrl>();
        itemDropCtrl.SetInventoryItem(inventoryItem);
        return itemDrop;
    }
    
}
