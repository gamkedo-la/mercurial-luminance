using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyOrbiter : MonoBehaviour
{
    [SerializeField] private float orbitSpeed = 0.35f;
    [SerializeField] private GameObject[] fairies;
    private int index = 0;
    private new Transform transform;

    private void Awake()
    {
        transform = base.transform;
    }

    // This activates the next fairy in the array so we can "simulate" the effect that the fairy arrived and was taken in by the tree. Needs polish.

    public void ActivateFairy()
    {
        if (index >= fairies.Length)
            return;

        Debug.Log("We're in " + index);

        fairies[index].SetActive(true);
        index++;
    }

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, orbitSpeed);
    }
}
