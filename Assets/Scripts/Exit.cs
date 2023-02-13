using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<ClientBehaviour>().served);
        if (other.GetComponent<ClientBehaviour>().served == true) //if the client is going home, destoy it
        {
            Destroy(other.gameObject);
        }
    }
}
