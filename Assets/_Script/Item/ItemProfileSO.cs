using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "No Name";
    public int maxStackDefault = 7;
    public List<ItemRecipe> upgradeLevelRequired;
}
