
using System;

[Serializable]
public class InventoryItem
{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int level = 0;

    public virtual InventoryItem Clone()
    {
        InventoryItem item = new InventoryItem
        {
            itemProfile = itemProfile,
            itemCount = itemCount,
            maxStack = maxStack
        };

        return item;
    }
}