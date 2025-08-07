using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKey : MonoBehaviour
{

    [SerializeField] protected float speed = 5f;
    [SerializeField] Vector2 movement;

    [SerializeField] protected Rigidbody rb;
   
    public SpriteRenderer spriteRenderer;
    protected Vector3 mousePos;
    protected SpriteManager spriteManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        spriteManager = SpriteManager.Instance;
        spriteRenderer = spriteManager.spriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpriteDirection();
    }
    void FixedUpdate()
    {
        MoveWithKeyMethod();
    }

    private void UpdateSpriteDirection()
    {
        mousePos = InputManager.Instance.MouseWorldPos;
        Vector3 direction = (mousePos - transform.position).normalized;

        // Chọn sprite theo hướng
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            spriteRenderer.sprite = spriteManager.sideSprite;
            spriteRenderer.flipX = (direction.x > 0); // Lật sprite khi hướng trái
        }
        else
        {
            spriteRenderer.flipX = false; // Reset tránh lỗi hiển thị
            spriteRenderer.sprite = (direction.y > 0) ? spriteManager.upSprite : spriteManager.downSprite;
        }
    }

    protected void MoveWithKeyMethod()
    {
        this.movement = InputManager.Instance.Movement;
        rb.velocity = movement * speed;
    }
}
