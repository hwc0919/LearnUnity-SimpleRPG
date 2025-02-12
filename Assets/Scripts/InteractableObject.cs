using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    public void OnClick(NavMeshAgent playerAgent)
    {
        // TODO: move to nearby
        playerAgent.SetDestination(transform.position);
        // TODO: interact after arrived
        Interact();
    }

    protected virtual void Interact()
    {
        print("Interacting with object");
    }
}
