using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ClientBehaviour : MonoBehaviour
{
    public NavMeshAgent client; //the IA agent handeling the physics parameters of the client move
    public Canvas uIRequest; // the display of the beer requested
    private GameObject cameraToFace; // to be sure the request will stay in front of the viewer
    private GameObject barToFace; // to be sure the client will look at the bar
    public int beerTypeRequest; // to set the beer request of each client (on the inspector) used later to transfer the request to the chair
    private float drinkTimer = 5.0f;
    private Transform spawnManagerPosition; // Transform to store the Spawn manager location (used by the client to go back)
    public bool served = false; //Used to avoid a new customer to be destroyed when he cross the spawn manager trigger

    private void Start()
    {
        //we take the list of all chairs and if at least one is available we set the destination in a transform variable
        uIRequest.enabled = false;
        
        cameraToFace = GameObject.FindGameObjectWithTag("MainCamera"); // set the location of the camera 
        barToFace = GameObject.FindGameObjectWithTag("Bar");// set the location of the bar
        spawnManagerPosition = GameObject.FindGameObjectWithTag("SpawnManager").transform; //Set the location of the Spawn Manager

        MoveClient(CheckForAChair());

        
    }

    private void Update()
    {
        //We move the client each frame until the destination
        LookAtCamera();
    }

    private Transform CheckForAChair() //ABSTRACTION (used to find an empty chair to guide the client, I used this function in the Start Method at the first place)
    {
        GameObject[] chairsList = GameObject.FindGameObjectsWithTag("Chair");
        Transform emptyChairPosition = null;
        for (int i = 0; i < chairsList.Length; i++)
        {
            if (chairsList[i].GetComponent<Chair>().isEmpty == true)
            {
                //We set the destination
                emptyChairPosition = chairsList[i].transform;
                //we reserve the chair (to avoid other client to use the same chair)
                chairsList[i].GetComponent<Chair>().isEmpty = false;
                break;
            }
        }
        return emptyChairPosition;
    }

    // function to move the client to the destination using NavMesh
    private void MoveClient(Transform clientDestination) //the move of each client
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

    private void GoBack() // Used to ask the custom to go back
    {
        served = true;
        client.SetDestination(spawnManagerPosition.position);
    }

    public void Drink() // all steps to do when the client's order is validated
    {
        HideRequest(); 
        StartCoroutine(DrinkRoutine()); //we start a coroutine to wait some time before asking the client to go back
        IEnumerator DrinkRoutine()
        {
            //We wait before instantiating again
            yield return new WaitForSeconds(drinkTimer);
            GoBack();
        }

    }
}
