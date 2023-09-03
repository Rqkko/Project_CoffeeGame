using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string idName;
    private SpriteRenderer spriteRenderer;

    // Canvas stuff
    private GameObject canvasPrefab;
    private FoodCanvas foodCanvas;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canvasPrefab = Resources.Load<GameObject>("Prefabs/UI/CoffeeCup");
        foodCanvas = GameObject.FindGameObjectWithTag("FoodCanvas").GetComponent<FoodCanvas>();
    }

    // Run when clicked
    public void Click(Vector2 clickPosition)
    {
        spriteRenderer.enabled = false;
        foodCanvas.Create(canvasPrefab, clickPosition);
    }

    public void Move(Vector2 targetPosition)
    {
        foodCanvas.Move(targetPosition);
    }

    // Run when release mouse
    public void Release()
    {
        spriteRenderer.enabled = true;
        foodCanvas.Remove();
    }
}
