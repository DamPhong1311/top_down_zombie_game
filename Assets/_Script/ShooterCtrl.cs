using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCtrl : MonoBehaviour
{
    private static ShooterCtrl instance;

    public static ShooterCtrl Instance { get => instance;}

    [SerializeField] public Transform shooter;

    void Awake()
    {
        if (ShooterCtrl.instance != null) Debug.LogError("Only one ShooterCtrl is allowed to exist.");
        ShooterCtrl.instance = this;
    }
}
