using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFallow : InteractableScript
{
    PetScript pet;
    public override void Interact()
    {
        base.Interact();
        pet = GetComponent<PetScript>();
        pet.startFallow= !pet.startFallow;
        pet.AddStatus();
      //  Debug.Log("pet");
    }


}
