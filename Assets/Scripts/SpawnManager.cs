using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] clientsList;

   //instanciate a random client in the spawnmanager area
    void SpawnClient()
    {
        Instantiate(clientsList[Random.Range(0, clientsList.Length)],transform);
    }
}
