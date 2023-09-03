using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float walkSpeed = 1;
    private bool isOutside;
    private bool isEntering;
    public bool isReadyToOrder;

    private QueueManager queueManager;
    private int currentQueue;
    private Vector3 currentQueuePos; // Where to stand when queing

    public string foodWanted;
    private GameObject foodText; // Display when ordering

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        queueManager = GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueManager>();
        queueManager.customersInQueue.Add(gameObject);
        currentQueue = queueManager.customersInQueue.IndexOf(gameObject);

        isOutside = true;
        isEntering = false;
        isReadyToOrder = false;
        currentQueuePos = new Vector3(queueManager.orderPos.x, queueManager.orderPos.y, GetQueuePosZ());

        foodWanted = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>().GetRandomFoodInMenu();
        foodText = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        foodText.GetComponent<TextMeshProUGUI>().text = foodWanted;

        animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        // Walking to the door from outside
        if (isOutside) 
        {
            if (transform.position != queueManager.entryPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, queueManager.entryPos, walkSpeed * Time.deltaTime);
            }
            else
            {
                isOutside = false;
                isEntering = true;
            }
        }

        // Walking to the queue
        else if (isEntering)
        {
            if (transform.position != currentQueuePos)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentQueuePos, walkSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetTrigger("Idle");

                // On the order position
                if (transform.position == queueManager.orderPos)
                {
                    isReadyToOrder = true;
                    isEntering = false;
                }
            }
        }

        // Ordering
        else if (isReadyToOrder)
        {
            if (!foodText.activeSelf)
            {
                foodText.SetActive(true);
            }
        }
    }

    // Z position of where to stand and wait for the queue to run
    public float GetQueuePosZ()
    {
        return queueManager.orderPos.z + queueManager.queuePosGapZ * currentQueue;
    }

    // When served
    public void Serve()
    {
        queueManager.customersInQueue.Remove(gameObject);
        Destroy(gameObject);
        queueManager.RunQueue();
    }

    public void DecreaseCurrentQueue()
    {
        currentQueue--;
        currentQueuePos = new Vector3(queueManager.orderPos.x, queueManager.orderPos.y, GetQueuePosZ());
        animator.SetTrigger("Walk");
    }

    public void CheckCorrectFood(Food food)
    {
        if (food.idName == foodWanted)
        {
            Serve();
            Destroy(food.gameObject);
        }
        else
        {
            Debug.Log("Wrong food!");
        }
    }
}
