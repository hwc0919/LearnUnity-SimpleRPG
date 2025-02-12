using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent currentAgent;
    private int interactDistance = 2;

    public void OnClick(NavMeshAgent playerAgent)
    {
        currentAgent = playerAgent;
        // move to nearby
        playerAgent.stoppingDistance = interactDistance;
        playerAgent.SetDestination(transform.position);
    }

    private void Update()
    {
        // TODO: not totally correct. Click NPC, then click elsewhere, Interact() will also be called upon arriving.
        if (currentAgent != null && !currentAgent.pathPending)
        {
            if (currentAgent.remainingDistance <= interactDistance)
            {
                Interact();
                currentAgent = null;
            }
        }
    }

    protected virtual void Interact()
    {
        print("Interacting with object");
    }
}
