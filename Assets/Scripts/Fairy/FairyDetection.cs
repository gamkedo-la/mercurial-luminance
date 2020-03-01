using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDetection : MonoBehaviour
{
    private FairyMovement movement;
    private bool attachedToPlayer = false;

    private void Awake()
    {
        movement = GetComponent<FairyMovement>();
    }

    //We check if an object we're supposed to move to is within reach. Given the fairy will never be next to the tree we don't need to check if this is a player or not on first run. It will always
    // be the player. Meanwhile we check if we moved to the player then our next move target is the tree thus we flip a switch (attachedToPlayer) to confirm this. 
    // Each time we detect a target to move to, we call the movement script to move the fairy. 
    // In case of a tree we move there, switch ourselves off and activate the fairy dorment in the tree (quicker that way for now). Probably needs to be redone in some sort of cutscene-ish setup.

    private void OnTriggerEnter(Collider _other)
    {
        FairyTarget fairyTarget = _other.GetComponent<FairyTarget>();

        if (fairyTarget != null && attachedToPlayer == false)
        {
            if (movement.isMoving)
                return;

            movement.StartCoroutine(movement.LerpToTarget(fairyTarget.transform));
            attachedToPlayer = true;
        }
        else if (fairyTarget != null && attachedToPlayer)
            StartCoroutine(DeliverToTreeRoutine(fairyTarget.transform));
    }

    private IEnumerator DeliverToTreeRoutine(Transform _target)
    {
        transform.SetParent(null);

        yield return movement.StartCoroutine(movement.LerpToTarget(_target));

        FairyOrbiter orbiter = _target.GetComponentInChildren<FairyOrbiter>();

        orbiter.enabled = true;
        orbiter.ActivateFairy();

        yield return 0;

        gameObject.SetActive(false);
    }
}
