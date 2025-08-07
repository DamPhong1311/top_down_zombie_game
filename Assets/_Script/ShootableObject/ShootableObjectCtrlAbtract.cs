using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrlAbtract : MonoBehaviour
{
    [SerializeField] private Despawn despawn; public Despawn Despawn { get => despawn;  }
    [SerializeField] private Spawner spawner; public Spawner Spawner { get => spawner;}
    [SerializeField] private ShootableObjectSO shootableObjectSO; public ShootableObjectSO ShootableObjectSO { get => shootableObjectSO;}
}
