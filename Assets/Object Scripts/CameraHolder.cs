using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHolder : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    private float cPSpeed;
    private Vector3 prevPos;
    [SerializeField]  private bool playerMoving;

    //
    public Camera cam;
    public CinemachineFreeLook normalCam;
    public cam2 normalCam2;
    public Vector2 trasparentClamp;
    public Vector2[] setOrbs = new Vector2[3];
    public float zoomScale;
    public float zoomSensy;
    public float minZoom = 0.2f;
    public float minTrans = 0.05f;
    public Material mat;
    [SerializeField] private float targetZoom;
    public float scrollSpeed;
    public float scrollSpeed1;
    [SerializeField] private Transform realLookPoint;
    [SerializeField] private Transform childLookPoint;

    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        // created my own point did not work for some reason
        realLookPoint = new GameObject("realLookP").GetComponent<Transform>();
        normalCam.LookAt = realLookPoint;
        print(realLookPoint.position);
        targetZoom = zoomScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Zoom();
        Transparancy();
        StopLook();
        PlayerMovingCheck();
        CameraPoint();
    }

    void Transparancy()
    {
        float dist = Mathf.Abs(Vector3.Distance(transform.position, cam.transform.position));  
        float a = (Mathf.Clamp(dist, trasparentClamp.y, trasparentClamp.x) - trasparentClamp.y) / (trasparentClamp.x - trasparentClamp.y);
        if (inputC.rightC)
        {
            a = minTrans;

        }
        else
        {
            a = Mathf.Clamp(a, minTrans, 1);
        }

        Color colorHold;
        colorHold = mat.color;
        colorHold.a = a;
        mat.color = colorHold;
    }
    void StopLook()
    {
        if (inputC.rightC)
        {
            normalCam.enabled = false;
            normalCam2.enabled = true;
        }
        else
        {
            normalCam.enabled = true;
            normalCam2.enabled = false;
        }

    }
    void Zoom()
    {



        targetZoom += (zoomSensy * Input.mouseScrollDelta.y * Time.deltaTime);
        targetZoom = Mathf.Clamp(targetZoom, minZoom, 1);
        zoomScale += Mathf.Pow(targetZoom - zoomScale, 2) * (targetZoom - zoomScale > 0 ? 1 : -1);
        zoomScale = Mathf.Clamp(zoomScale, minZoom, 1);

        normalCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(setOrbs[0].x * zoomScale, setOrbs[0].y * zoomScale);
        normalCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(setOrbs[1].x * zoomScale, setOrbs[1].y * zoomScale);
        normalCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(setOrbs[2].x * zoomScale, setOrbs[2].y * zoomScale);


        
    }
    void CameraPoint()
    {
        float distance = Vector3.Distance(realLookPoint.position, childLookPoint.position);

       if(distance > 0.01f && playerMoving)
        {
            cPSpeed += 0.001f;
            realLookPoint.position = Vector3.MoveTowards(realLookPoint.position, childLookPoint.position, ( cPSpeed * Mathf.Pow(distance,2)) );
        }
        else
        {
            cPSpeed = 0;
        }
    }
    void PlayerMovingCheck()
    {
        if(prevPos != transform.position)
        {
            playerMoving = true;
        }
        else
        {
            playerMoving = false;
        }
        prevPos = transform.position;
    }
}
