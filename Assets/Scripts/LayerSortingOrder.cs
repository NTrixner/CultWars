using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSortingOrder : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rigidbody != null && spriteRenderer != null)
        {
            Debug.Log("Set Rigidbody and SpriteRenderer");
            spriteRenderer.sortingOrder = (int) (rigidbody.position.y * -100);
        }
    }
}
