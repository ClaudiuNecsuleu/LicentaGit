using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetScript : MonoBehaviour
{
    Transform playerFallow;
    [HideInInspector]
    public bool startFallow = false;
    NavMeshAgent agent;
    void Start()
    {
        playerFallow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent=GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (startFallow)
        {
            float distanceCurrent = Vector3.Distance(transform.position, playerFallow.position);
            if (distanceCurrent > 3)
            {
                agent.isStopped = false;
                agent.SetDestination(playerFallow.position);
               
            }
            if (distanceCurrent < 2)
                agent.isStopped = true;
        }
    }

    public void AddStatus()
    {
        if (startFallow)
        {
            CharacterStats.Instance.damage.AddEquipment(3);
            CharacterStats.Instance.armour.AddEquipment(1);
        }
        else {
            CharacterStats.Instance.damage.RemoveModifier(3);
            CharacterStats.Instance.armour.RemoveModifier(1);
        }
        
        CharacterStats.Instance.onItemChangeStatusCallMe.Invoke();
    }
}
