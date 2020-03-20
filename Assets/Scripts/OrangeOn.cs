using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeOn : MonoBehaviour
{
    public GameObject[] itemToToggle;
    public string tagToCheck = "Orange";

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToCheck)
        {
            foreach(GameObject item in itemToToggle)
            {
                if(item.activeSelf == true)
                {
                    item.SetActive(false);
                    //Debug.Log("Deactivating.");
                }
                else
                {
                    item.SetActive(true);
                    //Debug.Log("Activating.");
                }
            }
        }
    }
}
