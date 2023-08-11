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
    private Vector3 queuePos; // Where to stand when queing

    private List<GameObject> foodsInMenu;
    public string foodWanted;
    private GameObject foodText;

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
        queuePos = new Vector3(queueManager.orderPos.x, queueManager.orderPos.y, GetQueuePosZ());

        foodsInMenu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>().foodsInMenu;
        foodWanted = GetRandomFood();
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
            if (transform.position != queuePos)
            {
                transform.position = Vector3.MoveTowards(transform.position, queuePos, walkSpeed * Time.deltaTime);
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
    [ContextMenu("Serve")]
    public void Serve()
    {
        queueManager.customersInQueue.Remove(gameObject);
        Destroy(gameObject);
        queueManager.RunQueue();
    }

    public void DecreaseQueue()
    {
        currentQueue--;
        queuePos = new Vector3(queueManager.orderPos.x, queueManager.orderPos.y, GetQueuePosZ());
        animator.SetTrigger("Walk");
    }

    private string GetRandomFood()
    {
        int foodIndex = Random.Range(0, foodsInMenu.Count);
        return foodsInMenu[foodIndex].name;
    }

    public void CheckCorrectFood(string food)
    {
        if (food == foodWanted)
        {
            Serve();
        }
        else
        {
            Debug.Log("Wrong food!");
        }
    }
}
