using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnSpeed = 1.0f;
    private float driveSpeed = 0.0f;
    private float pitchFacing = 0.0f;
    private float yawFacing = 0.0f;
    public float forwardSpeed = 5.0f;
    public float fastForwardSpeed = 10.0f;
    public float normalForwardSpeed = 5.0f;
    private float zVel = 0.0f;
    public float minAlt = 0.5f;
    private Transform latePosition;
    private float fallTime;
    private float timer;
    public Vector3 lastPosition;
    private float oldTime;
    public GameObject endGame;
    public bool endActivated;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        endGame = GameObject.FindGameObjectWithTag("EndGame");
        //endGame.SetActive(false);
        endActivated = false;
        endGame.SetActive(endActivated);
    }

    void FixedUpdate()
    {
        float kValue = 0.3f;
        turnSpeed = Input.GetAxisRaw("Horizontal") * (1.0f - kValue) + turnSpeed * kValue;

        kValue = 0.9f;
        driveSpeed = Input.GetAxisRaw("Vertical") * (1.0f - kValue) + driveSpeed * kValue;
    }

    // Update is called once per frame
    void Update()
    {
        //endGame = GameObject.FindGameObjectWithTag("EndGame");
        if (endGame.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Debug.Log("Cursor Active");
        }

        else
        {
            transform.position += transform.forward * Time.deltaTime * forwardSpeed * driveSpeed + zVel * Vector3.up;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                forwardSpeed = fastForwardSpeed;
            }

            RaycastHit rhInfo;
            LayerMask cameraMask = ~LayerMask.GetMask("Player", "NPC"); // ~ for "everything but"
            if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, minAlt, cameraMask))
            {
                oldTime += Time.deltaTime;
                transform.position = rhInfo.point + minAlt * Vector3.up;
                timer = 0.0f;
                lastPosition = transform.position;

                //Debug.Log("Saving Position");
                zVel = 0.0f;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SoundPlayer.PlayClipByName(SoundNames.wind_woosh, Random.Range(0.9f, 1.0f));
                    zVel = 0.2f;
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 3.0f)
                {
                    timer = 0.0f;
                    transform.position = lastPosition;
                    Debug.Log("LastPosition Happening");
                    zVel = 0.0f;
                }
                zVel += -.4f * Time.deltaTime;
            }
        }


        //spin with our keys
        //transform.Rotate(Vector3.up, turnSpeed * 40.0f * Time.deltaTime);
        //Mouse
        //transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * 40.0f * Time.deltaTime);
        //transform.Rotate(transform.right, Input.GetAxisRaw("Mouse Y") * 40.0f * Time.deltaTime);

        yawFacing += turnSpeed * 40.0f * Time.deltaTime;
        yawFacing += Input.GetAxisRaw("Mouse X") * 40.0f * Time.deltaTime;
        
        pitchFacing -= Input.GetAxisRaw("Mouse Y") * 40.0f * Time.deltaTime;
        pitchFacing = Mathf.Clamp(pitchFacing, -30.0f, 30.0f);

        transform.rotation = Quaternion.AngleAxis(yawFacing, Vector3.up) *
            Quaternion.AngleAxis(0 /*pitchFacing*/, Vector3.right);
    }

}
