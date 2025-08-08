using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }


    [SerializeField] private Vector3 mouseWorldPos; public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] private Vector3 movement; public Vector3 Movement { get => movement; }
  

    [SerializeField] private float getShootInput;  public float GetShootInput { get => getShootInput; }
    [SerializeField] private float ultimate;  public float Ultimate { get => ultimate; }
    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only one InputManager is allowed to exist.");
        InputManager.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        GetAxisMovement();
        
    }

    public Vector3 GetMousePosition()
    {
        return this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetAxisMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        getShootInput = Input.GetAxisRaw("Fire1");
        ultimate = Input.GetAxisRaw("PressX");
    }
}
