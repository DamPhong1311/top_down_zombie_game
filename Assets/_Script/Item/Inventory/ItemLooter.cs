using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ItemLooter : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    void Awake()
    {
        if (_rigidbody == null) Debug.LogError("_rigidbody is null in" + transform.name);
        if (sphereCollider == null) Debug.LogError("_sphereCollider is null in" + transform.name);
        if (inventory == null) Debug.LogError("inventory is null in" + transform.name);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        InventoryItem inventoryItem =  itemPickupable.ItemDropCtrl.InventoryItem;
        if(inventory.AddItem(inventoryItem)){
            itemPickupable.Picked();
        }
    }
}
