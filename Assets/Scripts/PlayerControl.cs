using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour

{
    public NavMeshAgent innkeeper;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveInnkeeper();
        }
    }

    private void MoveInnkeeper()

    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                innkeeper.SetDestination(hit.point);
            }
    }
}
