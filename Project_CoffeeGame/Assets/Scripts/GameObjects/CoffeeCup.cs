using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCup : MonoBehaviour, IClickable
{
    public string objectName = "CoffeeCup";
    public FoodCanvas foodCanvas;

    public void Click(Vector3 position)
    {
        gameObject.SetActive(false);
        foodCanvas.Create(objectName, position);
    }
}
