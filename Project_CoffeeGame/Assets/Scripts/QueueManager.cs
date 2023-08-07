using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public GameObject[] customerPrefabs;
    private float timeElapsed;
    public float customerSpawnTime;
    public float customerSpawnPosX;
    public List<GameObject> customersInQueue;
    public float maxQueue;

    public Vector3 entryPos; 
    public Vector3 orderPos; // Customer needs to stand here to order
    public float queuePosGapZ;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        customersInQueue = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed >= customerSpawnTime && customersInQueue.Count < maxQueue)
        {
            int customerIndex = Random.Range(0, customerPrefabs.Length);
            Vector3 spawnPos = new Vector3(GetRandomSpawnSide(), transform.position.y, transform.position.z);
            Instantiate(customerPrefabs[customerIndex], spawnPos, transform.rotation);
            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }

    // Get spawn side (left or right of the building
    private float GetRandomSpawnSide()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            return -customerSpawnPosX;
        }
        return customerSpawnPosX;
    }

    // Run the queue
    public void RunQueue()
    {
        for (int i = 0; i < customersInQueue.Count; i++)
        {
            customersInQueue[i].GetComponent<Customer>().DecreaseQueue();
        }
    }

    // Serve the customer ordering
    public void ServeCurrentCustomer()
    {
        customersInQueue[0].GetComponent<Customer>().Serve();
    }
}
