using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ClientBehaviour : MonoBehaviour
{
    public NavMeshAgent client; //the IA agent handeling the physics parameters of the client move
    private GameObject[] chairsList; //list of chairs (to calculate which one is available)
    private Transform clientDestination; //To set the location of each client's chair 
    public Canvas uIRequest; // the display of the beer requested
    private GameObject cameraToFace; // to be sure the request will stay in front of the viewer
    private GameObject barToFace; // to be sure the client will look at the bar
    public int beerTypeRequest; // to set the beer request of each client (on the inspector) used later to transfer the request to the chair

    private void Start()
    {
        //we take the list of all chairs and if at least one is available we set the destination in a transform variable
        uIRequest.enabled = false;
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
        cameraToFace = GameObject.FindGameObjectWithTag("MainCamera"); // set the location of the camera 
        barToFace = GameObject.FindGameObjectWithTag("Bar");// set the location of the bar
        MoveClient();

        
    }

    private void Update()
    {
        //We move the client each frame until the destination
        LookAtCamera();
    }

    // function to move the client to the destination using NavMesh
    private void MoveClient() //the move of each client
    {
        client.SetDestination(clientDestination.position);
    }

    private void LookAtCamera() //to be sure the client's 2D Canvas will stay in front of the camera
    {
        uIRequest.transform.rotation = Quaternion.LookRotation(transform.position - cameraToFace.transform.position);
    }

    private void LookAtTheBar() //to be sure the client will look at the bar
    {
        client.transform.rotation = Quaternion.LookRotation(transform.position - barToFace.transform.position);
    }

    public void DisplayRequest() // Display the beer request
    {
        uIRequest.enabled = true;
        LookAtTheBar();
    }

    public void HideRequest() // Hide the beer request
    {
        uIRequest.enabled = false;
    }

}
