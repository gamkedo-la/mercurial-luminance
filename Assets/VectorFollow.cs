using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player;
    public Transform pTransform;

    float mSpeed = 10.0f;

    public Vector3 mLookDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mLookDirection = (pTransform.position - pTransform.position).normalized;
        pTransform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
    }
}
