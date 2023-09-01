using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IItem, IInteractable
{
    public string IItem.itemName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
