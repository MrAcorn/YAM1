using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    //Higer Up Scripts
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    [SerializeField] private Camera cam;
    //Hold condition
    [SerializeField] private float currentJumps;
    private bool canJump;
    public bool grounded;
    public float currentHeight;
    public float reltiveGround;
    // Start is called before the first frame update
    void OnEnable()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();

        canJump = true;
        currentJumps = stats.maxJumps;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grounded)
        {
            reltiveGround = transform.position.y;
            currentHeight = 0;
        }
        else
        {
            currentHeight = transform.position.y - reltiveGround;
        }
        
        Invoke("Move", 0);
        //Grounded
        if (Mathf.Abs(rb.velocity.y)! >= 0.01f)
        {
            Invoke("Grounded", 0.03f);
        }
    }
    
    void rotate()
    {
        Vector3 viewDir = transform.position - new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);


        if(viewDir != Vector3.zero)
        {
            transform.forward = viewDir.normalized;
        }
    }
    void Move()
    {
        int Fmoveing = (inputC.Fwrd ? 1 : 0 ) + -(inputC.Bwrd ? 1 : 0);
        int Rmoveing = (inputC.Rwrd ? 1 : 0) + -(inputC.Lwrd ? 1 : 0);


        if( Mathf.Abs(Fmoveing) + Mathf.Abs(Rmoveing) != 0)
        {
            rotate();
        }
        Vector3 Fwrd1 = transform.TransformDirection(Vector3.forward);
        Vector3 Rwrd1 = transform.TransformDirection(Vector3.right);


        Vector3 Fwrd = new Vector3(Fwrd1.x, 0, Fwrd1.z) * stats.speed * Fmoveing;
        Vector3 Rwrd = new Vector3(Rwrd1.x, 0, Rwrd1.z) * stats.speed * Rmoveing;


        Vector3 ConstantMove = transform.position + Fwrd + Rwrd;
        rb.MovePosition(ConstantMove);


        if (inputC.up && canJump && (currentJumps > 0))
        {
            
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(new Vector3(0, stats.jumpHeight + (Mathf.Clamp(rb.velocity.y, rb.velocity.y, 0) * -stats.jumpConstitution), 0) + (Fwrd1 * Fmoveing) + (Rwrd1 * Rmoveing), ForceMode.Impulse);
            canJump = false;
            Invoke("JumpCD", stats.jumpCD);
        }
    }


    void JumpCD()
    {
        --currentJumps;
        canJump = true;
    }
    void Grounded()
    {
        if (Mathf.Abs(rb.velocity.y) <= 0.01f)
        {
            grounded = true;
            currentJumps = stats.maxJumps;
        }
        else
        {
            grounded = false;
        }
            
    }
}
