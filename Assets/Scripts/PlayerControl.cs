using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour

{
    public NavMeshAgent innkeeper; //the IA agent handeling the physics parameters of the client move
    public Camera cam; //used to raycast the destination of the Innkeeper
    public Canvas actualBeerCanvas; // Display of the selected beer, used to enable/disable
    public static int selectedBeer { get; private set; } // getter and setter of the handed beer
    [SerializeField]
    private Sprite[] beerList;


    void Start()

    {
        actualBeerCanvas.GetComponent<Canvas>().enabled = false; // we disable the picture of the beer to say the innkeeper has nthing in hand
        selectedBeer = 4; //we set 4 = no beer selected, as beer goes from 0 to 2.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //click mouse to move
        {
            MoveInnkeeper();
        }
        LookAtCamera(); // as for the client, used to be sure the display of the beer will face the  camera

    }

    private void MoveInnkeeper() //raycast move function
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //Move only if the pointer clicked an object with a physics
            {
                innkeeper.SetDestination(hit.point);
            }
    }
    private void LookAtCamera() //function to face the camera
    {
        actualBeerCanvas.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public void DisplayBeer() //Function to display the beer handed by the innkeeper
    {
        actualBeerCanvas.GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("Beer").GetComponent<Image>().sprite = beerList[selectedBeer];
    }

    public void SelectBeer(int newBeer) // Function used in BeerDistributor script to change the handed beer
    {
        selectedBeer = newBeer;
        Debug.Log("j'ai la biere " + selectedBeer);
    }
    public void HideBeer() //Function to display the beer handed by the innkeeper
    {
        actualBeerCanvas.GetComponent<Canvas>().enabled = false;
    }
}
