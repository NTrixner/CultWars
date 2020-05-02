using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSortingOrder : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (body != null && spriteRenderer != null)
        {
            Debug.Log("Set Rigidbody and SpriteRenderer");
            spriteRenderer.sortingOrder = (int)(body.position.y * -100);
            return;
        }
        if (body == null && spriteRenderer != null)
        {
            Debug.Log("Set Rigidbody and SpriteRenderer");
            spriteRenderer.sortingOrder = (int)(spriteRenderer.bounds.min.y * -100);
            return;
        }
    }
}