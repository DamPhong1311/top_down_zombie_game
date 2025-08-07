using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : MonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected int maxLevel = 0;
    void Start()
    {
        Invoke(nameof(Test), 1);
        Invoke(nameof(Test), 2);
        Invoke(nameof(Test), 3);
       
    }

    private void FixedUpdate()
    {

    }

    protected virtual void Test()
    {
        UpgradeItem(0);
    }

    protected virtual bool UpgradeItem(int itemIndex)
    {
        if (itemIndex >= inventory.inventoryItems.Count) return false;

        InventoryItem inventoryItem = inventory.inventoryItems[itemIndex];

        if (inventoryItem.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = inventoryItem.itemProfile.upgradeLevelRequired;

        if (!CanUpgradeItem(upgradeLevels)) return false;
        if (!HaveEnoughIngredients(upgradeLevels, inventoryItem.level)) return false;
        if (inventoryItem.level >= maxLevel) return false;

        DeductIngredients(upgradeLevels, inventoryItem.level);
        inventoryItem.level++;

        return true;
    }



    protected virtual bool CanUpgradeItem(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if (currentLevel >= upgradeLevels.Count) return false;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;

            if (!inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;

            inventory.RemoveItem(itemCode, itemCount);
        }
    }


}
