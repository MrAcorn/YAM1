using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCStatus : MonoBehaviour
{
    //Higer Up Scripts
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    //Hold condition
    //Negitive
    public bool stun;
    public float slow;
    public bool silence;
    public bool root;
    public bool disarm;
    public bool grounded;
    public bool cripple;
    //Positive
    public bool invinciblity;
    public bool statBuff;
    public bool sheilded;
    public bool unstoppable;
    public bool immunized;
    //neutral
    public bool wiffCancel;
    public bool knockDown;
    public bool stasis;
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PosCleanse()
    {

    }
    public void NegCleanse()
    {
    stun = false;
    slow = 0;
    silence = false;
    root = false;
    disarm = false;
    grounded = false;
    cripple = false;
}
    public void NeuCleanse()
    {

    }
}
