using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerDistributor : MonoBehaviour
{
    public int typeOfBeer; //Type of beer delivered by the object to the Innkeeper

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerControl>().SelectBeer(typeOfBeer); //we set the beer handed by the Innkeeper
        other.GetComponent<PlayerControl>().DisplayBeer(); //display the beer when the beer is delivered
    }
}
