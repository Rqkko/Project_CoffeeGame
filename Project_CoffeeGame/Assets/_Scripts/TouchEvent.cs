using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEvent: MonoBehaviour
{
    private Food touchedFood;
    public FoodCanvas foodCanvas;

    public GameObject coffeeMachine;

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
                    if (rayHit.collider.gameObject.TryGetComponent(out IInteractable interactableObject))
                    {
                        interactableObject.Interact(touch.position);

                        if (rayHit.collider.gameObject.TryGetComponent(out Food food))
                        {
                            touchedFood = food;
                        }
                    }
                }
            }

            // Move (Food only for now)
            if (touch.phase == TouchPhase.Moved)
            {
                if (touchedFood)
                {
                    touchedFood.Move(touch.position);
                }
            }

            // Out
            if (touch.phase == TouchPhase.Ended)
            {
                if (touchedFood)
                {
                    Ray foodRay = Camera.main.ScreenPointToRay(foodCanvas.currentFood.transform.position);
                    RaycastHit foodRayHit;

                    if (Physics.Raycast(foodRay, out foodRayHit))
                    {
                        if (foodRayHit.collider.gameObject.TryGetComponent(out Customer customer))
                        {
                            // Food hit customer
                            if (customer.isReadyToOrder)
                            {
                                customer.CheckCorrectFood(touchedFood);
                            }
                        }
                    }
                    touchedFood.Release();
                    touchedFood = null;
                }
            }
        }
    }
}
