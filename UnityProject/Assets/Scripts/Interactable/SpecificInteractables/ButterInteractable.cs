using System;
using FlorianMan.Watch;
using UnityEngine;

public class ButterInteractable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    [SerializeField] private TextBoxActivated thisObjectTextBoxActivated;
    
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void OnMouseDown()
    {
        if (TimeManager.Instance.GetCurrentTime().Equals(Times.Afternoon))
        {
            spriteRenderer.enabled = false;
            collider.enabled = false;
        }
    }
}
