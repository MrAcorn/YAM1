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
    private CCCounterPlay ccCounterPlay;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;

    //
    public Camera cam;
    public CinemachineFreeLook normalCam;
    public Vector2 trasparentClamp;
    public Vector2 []setOrbs = new Vector2[3];
    public float zoomScale;
    public float zoomSensy;
    public float minZoom = 0.2f;
    public float minTrans = 0.05f;
    public Material mat;
    private Color colorHold;
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        ccCounterPlay = GetComponent<CCCounterPlay>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        //
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Zoom();
        Transparancy();
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
        print(dist + " " + a);
        colorHold = mat.color;
        colorHold.a = a;
        mat.color = colorHold;
    }
    void Zoom()
    {
        
        zoomScale = Mathf.Clamp((zoomScale + (zoomSensy * inputC.scroll * Time.deltaTime)),minZoom,1);
        
        normalCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(setOrbs[0].x * zoomScale, setOrbs[0].y * zoomScale);
        normalCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(setOrbs[1].x * zoomScale, setOrbs[1].y * zoomScale);
        normalCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(setOrbs[2].x * zoomScale, setOrbs[2].y * zoomScale);


        
    }
    void FunnyColor()
    {
        
    }

}
