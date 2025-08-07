using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    private static GameCtrl instance;

    public static GameCtrl Instance { get => instance;}
    [SerializeField] public Camera mainCamera;

    void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only one GameCtrl is allowed to exist.");
        if(mainCamera == null) Debug.LogError("Main camera in" + transform.name + "is null");
        GameCtrl.instance = this;
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
