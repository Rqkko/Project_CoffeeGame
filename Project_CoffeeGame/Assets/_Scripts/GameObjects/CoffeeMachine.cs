using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeCup;
    [SerializeField]
    private Vector3 offsetPosition = new Vector3(.05f, -.16f, -.05f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Make Coffee")]
    public void MakeCoffee()
    {
        Instantiate(coffeeCup, transform.position + offsetPosition, Quaternion.identity);
    }
}
