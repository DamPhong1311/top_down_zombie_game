using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected int maxItem = 70;
    [SerializeField] public List<InventoryItem> inventoryItems;

    void Start()
    {
        // AddItem(ItemCode.Meat, 25);
    }

    public virtual bool AddItem(InventoryItem inventoryItem){
        int addCount = inventoryItem.itemCount;
        ItemProfileSO itemProfileSO = inventoryItem.itemProfile;
        ItemCode itemCode = itemProfileSO.itemCode;
        ItemType itemType = itemProfileSO.itemType;

        if(itemType == ItemType.Equipment) return AddEquiment(inventoryItem); 

        return AddItem(itemCode, addCount);
    }

    public virtual bool AddEquiment(InventoryItem inventoryItem)
    {
        if(IsInventoryFull()) return false;

        InventoryItem item = inventoryItem.Clone();

        inventoryItems.Add(item);
        return true;
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = GetItemProfile(itemCode);
        InventoryItem itemExist;
        int newCount;
        int moreCount;
        int addRemain = addCount;
        int itemMaxStack;
        for (int i = 0; i < maxItem; i++)
        {
            itemExist = GetItemNotFull(itemCode);

            if(itemExist == null){
                if(IsInventoryFull()) return false;

                itemExist = CreateEmptyItem(itemProfile);
                inventoryItems.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                moreCount = itemMaxStack - itemExist.itemCount; 
                newCount = itemExist.itemCount + moreCount;
                addRemain -= moreCount;
            }
            else{
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount; 
            if(addRemain < 1) break;
        }
        return true;
    }

    protected virtual bool IsInventoryFull(){
        if(inventoryItems.Count >= maxItem){
            return true;
        }
        return false;
    }

    protected virtual int GetMaxStack(InventoryItem item){
        if(item == null) return 0;
        return item.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO)); //lấy tất cả ItemProfiles kiểu ItemProfileSO để kiểm tra
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue; // nếu k phải profile.itemCode hiện tại thì bỏ qua và đến cái tiếp
            return profile;
        }
        return null;
    }

    protected virtual InventoryItem CreateEmptyItem(ItemProfileSO item){
        InventoryItem inventoryItem = new InventoryItem{
            itemProfile = item,
            maxStack = item.maxStackDefault,
        };
        return inventoryItem;
    }
    protected virtual InventoryItem GetItemNotFull(ItemCode itemCode)
    {
        foreach (InventoryItem inventoryItem in inventoryItems)
        {
            if (inventoryItem.itemProfile.itemCode != itemCode) continue; // khac ten thi bo qua
            if (inventoryItem.itemCount == inventoryItem.maxStack) continue; // full stack thi bo qua
            return inventoryItem;
        }
        return null;
    }

     public virtual bool ItemCheck(ItemCode itemCode, int itemCount){
        int totalCount = ItemTotalCount(itemCode);
        return totalCount >= itemCount;
    }

    public virtual int ItemTotalCount(ItemCode itemCode){
        int totalCount = 0;
        foreach(InventoryItem inventoryItem in inventoryItems){
            if(inventoryItem.itemProfile.itemCode != itemCode) continue;
            totalCount += inventoryItem.itemCount;
        }
        return totalCount;
    }

    public virtual void RemoveItem(ItemCode itemCode, int count){
        InventoryItem inventoryItem;
        int deduct;
        for(int i = inventoryItems.Count -1; i>0; i--){
            if(count <= 0) break;

            inventoryItem = inventoryItems[i];

            if(inventoryItem.itemProfile.itemCode != itemCode)  continue;

            if(count > inventoryItem.itemCount){
                deduct = inventoryItem.itemCount;
                count -= inventoryItem.itemCount;
            }
            else{
                deduct = count;
                count = 0;
            }

            inventoryItem.itemCount -= deduct;

        }
        ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot(){
        
        InventoryItem inventoryItem;
        for(int i = inventoryItems.Count - 1; i >= 0; i--){  
            inventoryItem = inventoryItems[i];
            if(inventoryItem.itemCount == 0) inventoryItems.RemoveAt(i); 
        }
    }



    // public virtual bool AddItem(ItemCode itemCode, int addCount)
    // {
    //     InventoryItem inventoryItem = GetItemByCode(itemCode);

    //     int newCount = inventoryItem.itemCount + addCount;
    //     if (newCount > inventoryItem.maxStack) {return false;}

    //     inventoryItem.itemCount = newCount;
    //     return true;
    // }

    // public virtual bool RemoveItem(ItemCode itemCode, int count){
    //     InventoryItem inventoryItem = GetItemByCode(itemCode);
    //     if(inventoryItem.itemCount <= 0) return false;
    //     int newCount = inventoryItem.itemCount - count;

    //     inventoryItem.itemCount = newCount;
    //     return true;
    // }

    // protected virtual InventoryItem GetItemByCode(ItemCode itemCode)
    // {
    //     InventoryItem inventoryItem = inventoryItems.Find((item) => item.itemProfile.itemCode == itemCode);
    //     if (inventoryItem == null) inventoryItem = AddEmptyProfile(itemCode); // nếu chưa có item này thì tạo ra inventoryItem mới 
    //     else if (inventoryItem.maxStack == 0 && inventoryItem.itemProfile != null)
    //     inventoryItem.maxStack = inventoryItem.itemProfile.maxStackDefault;
    //     return inventoryItem;
    // }

    // protected virtual InventoryItem AddEmptyProfile(ItemCode itemCode)
    // {
    //     var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO)); //lấy tất cả ItemProfiles kiểu ItemProfileSO để kiểm tratra
    //     foreach (ItemProfileSO profile in profiles)
    //     {

    //         if (profile.itemCode != itemCode) continue; // nếu k phải profile.itemCode hiện tại thì bỏ qua và đến cái tiếp

    //         InventoryItem inventoryItem = new InventoryItem
    //         {
    //             itemProfile = profile,
    //             maxStack = profile.maxStackDefault,
    //             itemCount = 0
    //         };
    //         inventoryItems.Add(inventoryItem);
    //         return inventoryItem;
    //     }
    //     return null;
    // }
}
