using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
    public bool isMoving { get; private set; } = false;

    [SerializeField] private float movementSpeed = 2;
    [SerializeField] private float reachDestinationThreshold = 0.5f;
    private new Transform transform; // this might look weird. Monobehaviours come by default with a few variables such as transform and gameObject. In case of transform it referes to the 
    // transform of the object. Each time we call transform however we do an implicit GetComponent<Transform>() and while it is optimized, it is still taxing for an every frame call if we are doing
    // it a lot per frame. So to save on that we create our own copy of transform and assign the one Unity creates to our own one and use that instead. That way we can call transform a well known
    // variable in the Unity ecco system without worrying about performance. 

    private void Awake()
    {
        transform = base.transform;
    }

    // This is a coroutine that moves the fairy towards a target using movementSpeed and the threshold as when to stop.

    public IEnumerator LerpToTarget(Transform _target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, _target.position) > reachDestinationThreshold)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, movementSpeed * Time.deltaTime);

            yield return 0;
        }

        transform.SetParent(_target);

        isMoving = false;
    }

}
