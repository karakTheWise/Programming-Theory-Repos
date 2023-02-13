using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    // To make sure the client will not use the same chair than the others, we use a bool variable to know if a chair is available
    public bool isEmpty = true;
    public int beerRequested; // variable to store the client's beer requested
    private GameObject client; //as we don't only use Trigger function, we can't keep "other" as variable for the client

    private void Start()
    {
        beerRequested = 5; //we put a strange value, out of the range of beer
    }
    //function to set the chair as none available if a client is in the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        isEmpty = false;
        client = other.gameObject; // We set the client variable to be used with ServiceOK function
        other.GetComponent<ClientBehaviour>().DisplayRequest(); //we dislplay the request only when the client is waiting
        beerRequested = other.GetComponent<ClientBehaviour>().beerTypeRequest; //we store the client's beer request at the chair level (to the compared with beer handed by the Innkeeper)
    }
    //function to release the chair as available if a client get out of the trigger zone
    private void OnTriggerExit(Collider other)
    {
        isEmpty = true;
    }

    public void ServiceOK()
    {
        client.GetComponent<ClientBehaviour>().Drink(); //Drink is a function defined in ClientBehaviour, used to validate the client order and manage the next steps
        beerRequested = 5; //We assign 5 to "forget" the previous order
        client = null; // once the order is validated, the client is refreshed, to avoid the innkeeper to serve the client again
    }
}
