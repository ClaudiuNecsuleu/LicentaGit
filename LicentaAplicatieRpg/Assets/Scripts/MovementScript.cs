using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour
{
    public float speedCharacter = 1;
    public float speedRotation = 20;
    public Transform myPlayerTransform;

    InteractableScript interactable;

    [SerializeField] float smoothTime;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Vector3 targetToGo;
    Transform myObjectTransform;
    NavMeshAgent agent;
    Camera myCamera;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myObjectTransform = GetComponent<Transform>();
        myCamera = Camera.main;
    }

    void Update()
    {
        if (targetToGo != Vector3.zero)
        {
            if(interactable!=null)
            if (Vector3.Distance(targetToGo, myObjectTransform.transform.position) <= interactable.radius)
            {
                //   Debug.Log("AGENT STOP");
                agent.isStopped = true;

                targetToGo = Vector3.zero;

                interactable = null;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            agent.isStopped = true;

            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? 2 * speedCharacter : speedCharacter), ref smoothMoveVelocity, 0);
            myObjectTransform.position = myObjectTransform.position + myPlayerTransform.TransformDirection(moveAmount) * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            myCamera.transform.RotateAround(myPlayerTransform.position, Vector3.up, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime);
            myPlayerTransform.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime, 0);
        }
    }


    public void MovePlayerToDestination(Vector3 point,InteractableScript interact)
    {
        if (agent.isStopped == true)
            agent.isStopped = false;
        agent.SetDestination(point);
        targetToGo = point;
        interactable = interact;
    }

}
