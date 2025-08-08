using System;
using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] public Transform holder;

    protected void Reset()
    {
        LoadComponents();
    }


    protected virtual void Awake()
    {
        string nameObj = this.gameObject.name;
        if (prefabs.Count == 0) Debug.LogWarning("prefabs in " + nameObj + " is null, pls reset to receive list");
    }

    // Update is called once per frame
    protected void LoadComponents()
    {
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            prefabs.Add(prefab);
        }
        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform SpawnByName(string prefabName, Vector3 spawmPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        return this.SpawnByPrefab(prefab, spawmPos, rotation);
    }

    public virtual Transform SpawnByPrefab(Transform prefab, Vector3 spawmPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawmPos, rotation);
        newPrefab.parent = holder;
        return newPrefab;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform RandomPrefab()
    {
        int rand = UnityEngine.Random.Range(0, prefabs.Count);
        return prefabs[rand];
    }

}
