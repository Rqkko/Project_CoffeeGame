using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float rotateSpeed = 260;
    public bool isOpening;

    private float currentTurnAngle;

    // Start is called before the first frame update
    void Start()
    {
        isOpening = false;
        currentTurnAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Opening
        if (isOpening && currentTurnAngle < 90)
        {
            currentTurnAngle += rotateSpeed * Time.deltaTime;
            if (currentTurnAngle >= 90)
            {
                currentTurnAngle = 90;
            }
            transform.rotation = Quaternion.AngleAxis(currentTurnAngle, Vector3.up);
        } 
        // Closing
        else if (!isOpening && currentTurnAngle > 0)
        {
            currentTurnAngle -= rotateSpeed * Time.deltaTime;
            if (currentTurnAngle <= 0)
            {
                currentTurnAngle = 0;
            }
            transform.rotation = Quaternion.AngleAxis(currentTurnAngle, Vector3.up);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }

    public void CloseDoor()
    {
        isOpening = false;
    }
}
