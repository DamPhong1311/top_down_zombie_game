using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string ObjName = "Shootable Object";
    public ObjectType objectType;
    public float hpMax = 3;
    public List<DropRate> dropList;
}
