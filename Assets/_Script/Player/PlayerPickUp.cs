using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public virtual void ItemPickUp(ItemPickupable itemPickupable){
        InventoryItem inventoryItem = itemPickupable.ItemDropCtrl.InventoryItem;
        if(PlayerCtrl.Instance.Inventory.AddItem(inventoryItem)){
            itemPickupable.Picked();
        }
    }
}
