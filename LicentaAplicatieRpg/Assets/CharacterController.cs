using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    Camera cam;
    MovementScript playerMovement;
    public LayerMask layerMaskMovement;

    void Start()
    {
        cam = Camera.main;
        playerMovement = GetComponent<MovementScript>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerMaskMovement))
            {
                playerMovement.MovePlayerToDestination(hit.point);
            }
        }

        //interraction logic
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
               Debug.Log("We hit " + hit.collider.name + "  ,point " + hit.point);
            }
        }
       
    }
}
