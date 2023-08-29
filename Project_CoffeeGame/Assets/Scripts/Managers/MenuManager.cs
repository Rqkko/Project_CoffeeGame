using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> foodsInMenu;

    public string GetRandomFoodInMenu()
    {
        int foodIndex = Random.Range(0, foodsInMenu.Count);
        return foodsInMenu[foodIndex].name;
    }
}
