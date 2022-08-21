using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientBehaviour : MonoBehaviour
{
    public NavMeshAgent client;
    private GameObject[] chairsList;
    private Transform clientDestination;

    private void Start()
    {
        //we take the list of all chairs and if at least one is available we set the destination in a transform variable
        chairsList = GameObject.FindGameObjectsWithTag("Chair");
        for (int i = 0; i < chairsList.Length; i++)
        {
            if (chairsList[i].GetComponent<Chair>().isEmpty == true)
            {
                //We set the destination
                clientDestination = chairsList[i].transform;
                //we reserve the chair (to avoid other client to use the same chair)
                chairsList[i].GetComponent<Chair>().isEmpty = false;
                break;
            }
        }
    }

    private void Update()
    {
        //We move the client each frame until the destination
        MoveClient();
    }

    // function to move the client to the destination using NavMesh
    private void MoveClient()
    {
        client.SetDestination(clientDestination.position);
    }

}
