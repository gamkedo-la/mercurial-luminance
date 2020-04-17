using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    private ForceLook lookScript;
    private bool hasFired = false;

    public void WatchMeNow()
    {
        if(hasFired)
        {
            return;
        }
        hasFired = true;
        lookScript = Camera.main.GetComponent<ForceLook>();
        lookScript.lookAt = transform;
        StartCoroutine(WaitThenRelease());
    }

    IEnumerator WaitThenRelease()
    {
        yield return new WaitForSeconds(2.0f);
        lookScript.lookAt = null;
    }
}
