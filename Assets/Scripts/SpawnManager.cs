using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //list of all clients variants
    public GameObject[] clientsList;
    //Delay to spawn new client (to be changed in other modes
    private int delayToSpawn = 5;

    public void Start()
    {
        StartCoroutine(SpawnClientRoutine());
    }


    //instanciate a random client in the spawnmanager area
    IEnumerator SpawnClientRoutine()
    {
        //We check if the bar is full or not before instantiating new clients
        if (GameObject.FindGameObjectsWithTag("Client").Length < 5)
            {
            addClients();
            }
        //We wait before instantiating again
            yield return new WaitForSeconds(delayToSpawn);
        //we restart the Coroutine
            StartCoroutine(SpawnClientRoutine());
    }
    //function to randomly instantiate a client between the list of all variants
    private void addClients()
    {
        Instantiate(clientsList[Random.Range(0, clientsList.Length)], transform);
    }
    
}
