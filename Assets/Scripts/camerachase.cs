using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerachase : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private float timer;
    private bool SwitchFieldOfViewInterp;
    private bool FirstInitSwitch;
    private float timerFieldOfView;
    private float durationFieldOfView;
    private float StartFieldOfView;
    private float EndFieldOfView;

    private Vector3 PrevPos;
    private Vector3 NewPos;
    private Vector3 ObjVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 1.5f;
        durationFieldOfView = 0.8f;
        SwitchFieldOfViewInterp = false;
        timerFieldOfView = durationFieldOfView;
        StartFieldOfView = 90.0F;
        EndFieldOfView = 60.0F;
        FirstInitSwitch = false;
    }

    void FixedUpdate()
    {
        NewPos = transform.position;
        ObjVel = (NewPos - PrevPos) / Time.fixedDeltaTime;  
        PrevPos = NewPos;  
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float Offsetx;
        float Offsety;
        float FieldOfView;
        float SpeedTranslate;

        //If the player keeps a certain speed, we enter "travel mode" camera: larger view, bit like flowers
        //Debug.Log("Velocity" + ObjVel.magnitude);
        //Debug.Log("Angular Drag" + rb.angularDrag);

        if (ObjVel.magnitude >= 1)
        {
            timer -= Time.deltaTime;
        } else
        {
            timer = 1.5f;
        }

        if (timer <= 0)
        {
            Offsetx = 5.0f;
            Offsety = 0.3f;
            FieldOfView = 90.0F;

            SpeedTranslate = 0.6F;

            if (!SwitchFieldOfViewInterp)
            {
                SwitchFieldOfViewInterp = true;
                timerFieldOfView = 0.0F;
                StartFieldOfView = 60.0F;
                EndFieldOfView = 90.0F;
                FirstInitSwitch = true;
            }
        }
        else
        {
            Offsetx = 6.0f;
            Offsety = 5.0f;
            FieldOfView = 60.0F;
            SpeedTranslate = 0.3F;

            if (SwitchFieldOfViewInterp && FirstInitSwitch)
            {
                timerFieldOfView = 0.0F;
                SwitchFieldOfViewInterp = false;
                StartFieldOfView = 90.0F;
                EndFieldOfView = 60.0F;
            }
        }
        Vector3 camOffSet = -transform.forward * Offsetx;
        camOffSet.y = 0.0f;
        camOffSet = camOffSet.normalized * Offsety;
        camOffSet += Vector3.up * 3.0f;

        RaycastHit rhInfo;
        LayerMask cameraMask = ~LayerMask.GetMask("Player", "NPC"); // ~ for "everything but"
        float scaledBackBy = 1.0f;
        float camOffsetLength = camOffSet.magnitude;
        if (Physics.Raycast(transform.position, camOffSet, out rhInfo, camOffsetLength, cameraMask))
        {
            Debug.Log(rhInfo.collider.gameObject.name);
            camOffSet = rhInfo.point - transform.position;
            scaledBackBy = camOffSet.magnitude / camOffsetLength;
        }

        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, transform.position + camOffSet, ref velocity, SpeedTranslate);
        Camera.main.transform.LookAt(transform.position + Vector3.up * 2.0f * scaledBackBy);

        if (Camera.main.fieldOfView != EndFieldOfView)
        {
            timerFieldOfView += Time.deltaTime;
            if (timerFieldOfView > durationFieldOfView)
            {
                timerFieldOfView = durationFieldOfView;
            }
            Camera.main.fieldOfView = Mathf.Lerp(StartFieldOfView, EndFieldOfView, timerFieldOfView / durationFieldOfView);
        }
    }
}
