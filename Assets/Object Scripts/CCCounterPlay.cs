using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCCounterPlay : MonoBehaviour
{
    //Higer Up Scripts
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    //Hold condition
    public bool isSprinting;
    public bool abilityCast;
    public bool weaponCast;
    public bool movementCast;

    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
