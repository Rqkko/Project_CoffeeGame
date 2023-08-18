using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEvent: MonoBehaviour
{
    private GameObject touchedFood;
    public FoodCanvas foodCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray touchRay = Camera.main.ScreenPointToRay(touch.position);

            // Tap
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit rayHit;
                if (Physics.Raycast(touchRay, out rayHit))
                {
                    if (rayHit.collider.gameObject.CompareTag("Food"))
                    {
                        touchedFood = rayHit.collider.gameObject;
                        rayHit.collider.gameObject.SetActive(false);
                        foodCanvas.Create(touchedFood.name, touch.position);
                    }
                }
            }

            // Move
            if (touch.phase == TouchPhase.Moved && touchedFood)
            {
                foodCanvas.Move(touch.position);
            }

            // Out
            if (touch.phase == TouchPhase.Ended && touchedFood)
            {
                Ray foodRay = Camera.main.ScreenPointToRay(foodCanvas.currentFood.transform.position);
                RaycastHit foodRayHit;

                if (Physics.Raycast(foodRay, out foodRayHit))
                {
                    // Food hit the customer
                    if (foodRayHit.collider.gameObject.CompareTag("Customer"))
                    {
                        if (foodRayHit.collider.gameObject.GetComponent<Customer>().isReadyToOrder)
                        {
                            foodRayHit.collider.gameObject.GetComponent<Customer>().CheckCorrectFood(touchedFood.name);
                        }
                    }
                }
                touchedFood.SetActive(true);
                foodCanvas.Remove();
                touchedFood = null;
            }
        }
    }
}
