using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : InteractableScript
{ 
  

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interact with enemy");
        EnemyInteract enemy= GetComponent<EnemyInteract>();
        enemy.Attack();

    }
}
