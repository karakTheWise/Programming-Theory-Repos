using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    // To make sure the client will not use the same chair than the others, we use a bool variable to know if a chair is available
    public bool isEmpty = true;
    
    //function to set the chair as none available if a client is in the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        isEmpty = false;
    }
    //function to release the chair as available if a client get out of the trigger zone
    private void OnTriggerExit(Collider other)
    {
        isEmpty = true;
    }
}
