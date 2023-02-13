using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service : MonoBehaviour
{

    public GameObject associatedClient; //Used to link with the client in front of the bar

    private void OnTriggerEnter(Collider other) //When the innkeeper is in front of the client, we check if the client's request match with the handed beer.
    {
         if (PlayerControl.selectedBeer == associatedClient.GetComponent<Chair>().beerRequested)
        {
            Debug.Log("OK j'ai la biere" + PlayerControl.selectedBeer.ToString() + "Ma chaise a demandé la biere" + associatedClient.GetComponent<Chair>().beerRequested); //debug if yes
        }
        Debug.Log("j'ai la biere" + PlayerControl.selectedBeer.ToString() + "Ma chaise a demandé la biere" + associatedClient.GetComponent<Chair>().beerRequested);//debug if no
    }

}
