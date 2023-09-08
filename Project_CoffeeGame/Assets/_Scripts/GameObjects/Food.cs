using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
    public string idName;

    [Header("Components")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider boxCollider;

    // Canvas stuff
    [Header("Canvas Components")]
    [SerializeField]
    private GameObject canvasPrefab;
    [SerializeField]
    private FoodCanvas foodCanvas;

    private void Start()
    {
        foodCanvas = GameObject.FindGameObjectWithTag("FoodCanvas").GetComponent<FoodCanvas>();
    }

    public void Interact(Vector2 clickPosition)
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        foodCanvas.Create(canvasPrefab, clickPosition);
    }

    public void Move(Vector2 targetPosition)
    {
        foodCanvas.Move(targetPosition);
    }

    // Run when release mouse
    public void Release()
    {
        foodCanvas.Remove();
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
