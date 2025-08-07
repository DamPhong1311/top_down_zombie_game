using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    void Start()
    {
       Invoke(nameof(TestDrop), 4);
    }

    private void TestDrop(){
        Vector3 pos = transform.position;
        pos.x += 1;
        DropItemIndex(0, pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void DropItemIndex(int index, Vector3 pos, UnityEngine.Quaternion rot){
        InventoryItem inventoryItem = inventory.inventoryItems[index];
        

        ItemDropSpawner.Instance.Drop(inventoryItem, pos, rot);
        inventory.inventoryItems.Remove(inventory.inventoryItems[index]);
    }
}
