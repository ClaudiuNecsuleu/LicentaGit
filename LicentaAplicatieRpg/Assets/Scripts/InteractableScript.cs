using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    [HideInInspector]
    public bool playerWantToInteract = false;

   Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void Interact()
    {
         Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (playerWantToInteract == true)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                playerWantToInteract= false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
