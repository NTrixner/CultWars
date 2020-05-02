using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrificeable : MonoBehaviour
{

    [SerializeField] private HealthEntity healthEntity;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color regularColor;
    [SerializeField] private Color highlightColor;

    public void Highlight() {
        spriteRenderer.color = highlightColor;
    }

    public void RemoveHighlight() {
        spriteRenderer.color = regularColor;
    }

    public void Sacrifice() {
        healthEntity.Die();
    }
}
