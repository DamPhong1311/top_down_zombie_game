using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : MonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] private ItemDropCtrl itemDropCtrl;

    public ItemDropCtrl ItemDropCtrl { get => itemDropCtrl; set => itemDropCtrl = value; }

    void Awake()
    {
        if(sphereCollider == null) Debug.LogError("sphereCollider is null in " + transform.name);
    }

    public virtual void OnMouseDown() {
        // Debug.Log("Da nhat" + transform.parent.name);
        PlayerCtrl.Instance.PlayerPickUp.ItemPickUp(this);
    }

    protected virtual ItemCode StringToItemCode(string itemCode){
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemCode);
    }

    public virtual ItemCode GetItemCode(){
        ItemCode itemCode = StringToItemCode(transform.parent.name);
        return itemCode;
    }

    public virtual void Picked(){
        itemDropCtrl.Despawn.DespawnObj();
    }

    
}
