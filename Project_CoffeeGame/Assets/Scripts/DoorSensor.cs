using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    public DoorMover doorMover;

    private void OnTriggerStay(Collider other)
    {
        if (doorMover.isOpening == false)
        {
            doorMover.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorMover.CloseDoor();
    }
}
