using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerachase : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public Rigidbody rb;
    public float timer;
    public bool SwitchFieldOfViewInterp;
    public bool FirstInitSwitch;
    public float timerFieldOfView;
    public float durationFieldOfView;
    public float StartFieldOfView;
    public float EndFieldOfView;

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

    // Update is called once per frame
    void Update()
    {
        float Offsetx;
        float Offsety;
        float FieldOfView;
        float SpeedTranslate;
        
        //If the player keeps a certain speed, we enter "travel mode" camera: larger view, bit like flowers
        if(rb.velocity.magnitude >= 9.0)
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

            SpeedTranslate = 0.7F;

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
            Offsetx = 5.0f;
            Offsety = 3.0f;
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
