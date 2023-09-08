using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBeanBag : MonoBehaviour, IInteractable
{
    [SerializeField]
    private CoffeeMachine coffeeMachine;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact(Vector2 clickPosition)
    {
        coffeeMachine.MakeCoffee();
    }
}
