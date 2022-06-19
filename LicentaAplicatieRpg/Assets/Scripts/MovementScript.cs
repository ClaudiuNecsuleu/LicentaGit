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

    Vector3 targetToGo = Vector3.zero;
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
        if (agent.isStopped)
            targetToGo = Vector3.zero;

        if (targetToGo != Vector3.zero)
            FaceToTarget();

        if (interactable != null)
        {
            if (Vector3.Distance(targetToGo, myObjectTransform.transform.position) <= interactable.radius)
            {
                agent.isStopped = true;
                targetToGo = Vector3.zero;
                interactable = null;
            }
        }

        if (Vector3.Distance(targetToGo, myObjectTransform.transform.position) <= 2)
        {
            agent.isStopped = true;
            targetToGo = Vector3.zero;
            interactable = null;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            agent.isStopped = true;
            targetToGo = Vector3.zero;

            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? (speedCharacter + 2) : speedCharacter), ref smoothMoveVelocity, 0);
            myObjectTransform.position = myObjectTransform.position + myPlayerTransform.TransformDirection(moveAmount) * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            myCamera.transform.RotateAround(myPlayerTransform.position, Vector3.up, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime);
            myPlayerTransform.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime, 0);
            // GetComponent<Transform>().transform.Rotate(0, -myPlayerTransform.rotation.y, 0);
        }
    }


    public void MovePlayerToDestination(Vector3 point, InteractableScript interact)
    {
        if (agent.isStopped == true)
            agent.isStopped = false;
        agent.SetDestination(point);
        targetToGo = point;
        interactable = interact;
    }

    public void FaceToTarget()
    {
        Vector3 direction = (targetToGo - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        myPlayerTransform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 3f);
    }

}
