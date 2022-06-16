using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    Camera cam;
    MovementScript playerMovement;
    public LayerMask layerMaskMovement;
    public InteractableScript focus;
    void Start()
    {
        cam = Camera.main;
        playerMovement = GetComponent<MovementScript>();
    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerMaskMovement))
            {
                playerMovement.MovePlayerToDestination(hit.point, null);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //  Debug.Log("We hit " + hit.collider.name + "  ,point " + hit.point);
                InteractableScript interactable = hit.collider.GetComponent<InteractableScript>();
                if (interactable != null)
                {
                    playerMovement.MovePlayerToDestination(hit.point, interactable);
                    interactable.playerWantToInteract = true;
                }
            }
        }

    }
}
