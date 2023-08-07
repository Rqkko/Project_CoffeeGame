using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float rotateSpeed = 260;
    private bool opening;

    // Start is called before the first frame update
    void Start()
    {
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Opening
        if (opening)
        {
            if (transform.eulerAngles.y < 90)
            {
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                if (transform.eulerAngles.y > 90)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
                }
            }
        } 
        // Closing
        else
        {
            if (transform.eulerAngles.y < 350 && transform.eulerAngles.y != 0)
            {
                transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
                Debug.Log(transform.eulerAngles.y);
                if (transform.eulerAngles.y > 350)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                }
            }
        }
    }

    [ContextMenu("Open Door")]
    public void OpenDoor()
    {
        opening = true;
    }

    [ContextMenu("Close Door")]
    public void CloseDoor()
    {
        opening = false;
    }

    public void ToggleDoor()
    {
        opening = !opening;
    }
}
