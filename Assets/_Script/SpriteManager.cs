using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private static SpriteManager instance;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Sprite sideSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    public static SpriteManager Instance { get => instance;}

    void Awake()
    {
        SpriteManager.instance = this;
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
