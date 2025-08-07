using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    [SerializeField] private PlayerPickUp playerPickUp; public PlayerPickUp PlayerPickUp => playerPickUp;
    [SerializeField] private Inventory inventory; public Inventory Inventory => inventory; 
    void Awake()
    {
        PlayerCtrl.instance = this;
        if(playerPickUp == null) Debug.LogError(playerPickUp + "is null");
    }
}
