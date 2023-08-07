using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanvas : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public GameObject currentFood;
    private List<GameObject> foodsInMenu;

    void Start()
    {
        foodsInMenu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>().foodsInMenu;
    }

    public void Create(string foodName, Vector2 startingPosition)
    {
        currentFood = Instantiate(foodPrefabs[foodsInMenu.FindIndex(a => a.name == foodName)], transform.position, Quaternion.identity);
/*        currentFood = Instantiate(foodPrefabs[foodsInMenu.FindIndex(a => a.Contains(foodName))], transform.position, Quaternion.identity);*/
        currentFood.transform.SetParent(transform);
        currentFood.transform.position = startingPosition;
        currentFood.SetActive(true);
    }

    public void Move(Vector2 position)
    {
        currentFood.transform.position = position;
    }

    public void Remove()
    {
        Destroy(currentFood);
    }
}
