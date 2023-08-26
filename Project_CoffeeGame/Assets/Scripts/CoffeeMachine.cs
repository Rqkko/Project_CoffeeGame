using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeCup;
    private float x = 1.25f;
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
        Instantiate(coffeeCup, new Vector3(transform.position.x, transform.position.y-.25f, transform.position.z-.25f), Quaternion.identity);
    }
}
